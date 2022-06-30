using AllUp.DAL;
using AllUp.Extensions;
using AllUp.Helpers;
using AllUp.Models;
using AllUp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P129Allup.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(int? status, int page = 1)
        {
            IQueryable<Product> query = _context.Products.AsQueryable();
            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    query = _context.Products.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    query = _context.Products.Where(b => !b.IsDeleted);
                }
            }
            int itemcount = int.Parse(_context.Settings.FirstOrDefaultAsync(i => i.Key == "PageItemCount").Result.Value);
            List<Product> products = await query.Skip((page - 1) * itemcount).Take(itemcount).ToListAsync();
            ViewBag.Status = status;
            return View(PageNatedList<Product>.Create(page, query, itemcount));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = await _context.Brands.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.Brands = await _context.Brands.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if ( product.MainFormImage == null || product.HoverFormImage == null)
            {
                ModelState.AddModelError("File", "You should add an image");
                return View();

            }
            else
            {
                if (product == null || !await _context.Products.AnyAsync(b => b.Id == product.BrandId && !b.IsDeleted))
                {
                    ModelState.AddModelError("BrandId", "Not the right brand");
                    return View();
                }

            }
            if (await _context.Products.AnyAsync(b => b.Name.ToLower().Trim() == product.Name.ToLower().Trim() && !b.IsDeleted))
            {
                ModelState.AddModelError("Name", $"{product.Name} Already Exists");
                return View();
            }
            if (product.MainFormImage != null || product.HoverFormImage != null)
            {
                if (product.MainFormImage.CheckFileType("image/*") || product.HoverFormImage.CheckFileType("image/*"))
                {
                    ModelState.AddModelError("File", "The uploaded file should be an image (jpg, png, jpeg)");
                    return View();
                }
                if (product.MainFormImage.CheckFileSize(200) || product.HoverFormImage.CheckFileSize(200))
                {
                    ModelState.AddModelError("File", "The uploaded file should not exceed 200Kb ");
                    return View();
                }
            }
            
            Brand brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == product.BrandId);
            TempData["success"] = "Product was created successfully";
            product.CreatedAt = DateTime.UtcNow.AddHours(+4);
            product.Seria = (brand.Name.Substring(0, 2) + product.Name.Substring(0, 2)).ToLower();
            Random random = new Random();
            Random random2 = new Random();
            product.Code = random.Next(1, 1000) + random2.Next(1, 1000);

            product.Name = product.Name.Trim();
            product.Price = product.Price;
            product.DicountedPrice = product.DicountedPrice;
            product.Count = product.Count;
            product.Description = product.Description;
            product.ExTax = product.ExTax;
            product.MainImnage = await product.MainFormImage.CreateAsync(_env, "assets", "images", "mainimages");
            product.HoverImage = await product.HoverFormImage.CreateAsync(_env, "assets", "images", "hoverimages");
            //product.DetailImages = await product.DetailFormImages.CreateMultipleAsync(_env, "assets", "images", "detailimages");
            await _context.AddAsync(product);
            _context.SaveChanges();
            foreach (IFormFile image in product.DetailFormImages)
            {
                if (image != null)
                {
                    if (image.CheckFileType("image/*"))
                    {
                        ModelState.AddModelError("File", "The uploaded file should be an image (jpg, png, jpeg)");
                        return View();
                    }
                    if (image.CheckFileSize(200))
                    {
                        ModelState.AddModelError("File", "The uploaded file should not exceed 200Kb ");
                        return View();
                    }
                    Photo photo = new Photo();
                    photo.Image = await FileManger.CreateAsync(image, _env, "assets", "images", "detailimages"); ;
                    photo.ProductId = product.Id;
                    await _context.AddAsync(photo);
                    _context.SaveChanges();
                }
            }
            //string[] images = product.DetailImages.Split(',');
            //foreach (string image in images)
            //{
            //    Photo photo = new Photo();
            //    photo.Image = image;
            //    photo.ProductId = product.Id;
            //    await _context.AddAsync(photo);
            //    _context.SaveChanges();

            //}

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Brands = await _context.Brands.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            if (id == null)
            {
                return BadRequest();
            }
            Product dbproduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (dbproduct == null)
            {
                return NotFound();
            }
            return View(dbproduct);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(Product product, int? id)
        {
            ViewBag.Brands = await _context.Brands.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id == null)
            {
                return BadRequest();
            }
            if (id != product.Id)
            {
                return BadRequest();
            }
            Product dbproduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            Brand brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == product.BrandId);
            if (product.MainFormImage != null || product.HoverFormImage != null)
            {
                if (product.MainFormImage.CheckFileType("image/*") || product.HoverFormImage.CheckFileType("image/*"))
                {
                    ModelState.AddModelError("File", "The uploaded file should be an image (jpg, png, jpeg)");
                    return View();
                }
                if (product.MainFormImage.CheckFileSize(200) || product.HoverFormImage.CheckFileSize(200))
                {
                    ModelState.AddModelError("File", "The uploaded file should not exceed 200Kb ");
                    return View();
                }
            }
            dbproduct.Seria = (brand.Name.Substring(0, 2) + product.Name.Substring(0, 2)).ToLower();

            //dbproduct.Name = product.Name.Trim();
            //dbproduct.Price = product.Price;
            //dbproduct.DicountedPrice = product.DicountedPrice;
            //dbproduct.Code = product.Id;
            //dbproduct.Count = product.Count;
            //dbproduct.Description = product.Description;
            //product.ExTax = product.ExTax;
            //_context.Products.Update(product);
            _context.Entry(dbproduct).CurrentValues.SetValues(product);
            if (product.MainFormImage != null)
            {
                FileHelper.DeleteFile(_env, dbproduct.MainImnage, "assets", "images", "mainimages");
                dbproduct.MainImnage = await product.MainFormImage.CreateAsync(_env, "assets", "images", "mainimages");

            };
            if (product.HoverFormImage != null)
            {
                FileHelper.DeleteFile(_env, dbproduct.HoverImage, "assets", "images", "hoverimages");
                dbproduct.HoverImage = await product.HoverFormImage.CreateAsync(_env, "assets", "images", "hoverimages");
            }
            if (product.DetailFormImages != null)
            {
                List<Photo> photos = _context.Photos.Where(p => p.ProductId == product.Id).ToList();
                foreach (Photo photo in photos)
                {
                    FileHelper.DeleteFile(_env, photo.Image, "assets", "images", "detailimages");
                    _context.Photos.Remove(photo);
                    _context.SaveChanges();


                }
                foreach (IFormFile image in product.DetailFormImages)
                {
                    Photo photo = new Photo();
                    photo.Image = await FileManger.CreateAsync(image, _env, "assets", "images", "detailimages"); ;
                    photo.ProductId = product.Id;
                    _context.Update(photo);
                    _context.SaveChanges();
                    
                }
                //FileHelper.DeleteMultipleFiles(_env, dbproduct.DetailImages, "assets", "images", "detailimages");
                //dbproduct.DetailImages = await product.DetailFormImages.CreateMultipleAsync(_env, "assets", "images", "detailimages");
                //List<Photo> photos = _context.Photos.Where(p => p.ProductId == dbproduct.Id).ToList();
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id, int status, int page)
        {
            ViewBag.Status = status;

            IQueryable<Product> query = _context.Products.AsQueryable();
            int itemcount = int.Parse(_context.Settings.FirstOrDefaultAsync(i => i.Key == "PageItemCount").Result.Value);
            if (id == null)
            {
                return BadRequest();
            }
            Product dbproduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == id );
            
            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    query = query.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    query = query.Where(b => !b.IsDeleted);
                }
            }
            dbproduct.IsDeleted = true;
            dbproduct.DeletedAt = DateTime.UtcNow.AddHours(+4);
            _context.SaveChanges();
            return PartialView("_ProductIndexPartial", PageNatedList<Product>.Create(page, query, itemcount));
        }
        public async Task<IActionResult> Restore(int? id, int status, int page)
        {
            IQueryable<Product> query = _context.Products.AsQueryable();
            int itemcount = int.Parse(_context.Settings.FirstOrDefaultAsync(i => i.Key == "PageItemCount").Result.Value);
            if (id == null)
            {
                return BadRequest();
            }
            Product dbproduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    query = query.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    query = query.Where(b => !b.IsDeleted);
                }
            }
            ViewBag.Status = status;

            dbproduct.IsDeleted = false;
            _context.SaveChanges();
            return PartialView("_ProductIndexPartial", PageNatedList<Product>.Create(page, query, itemcount));
        }
    }
}