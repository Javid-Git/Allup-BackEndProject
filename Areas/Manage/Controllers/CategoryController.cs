using AllUp.DAL;
using AllUp.Extensions;
using AllUp.Helpers;
using AllUp.Models;
using AllUp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult > Index(int? status, int page = 1)
        {
            IQueryable<Category> query = _context.Categories.AsQueryable();
            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    query = _context.Categories.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    query = _context.Categories.Where(b => !b.IsDeleted);
                }
            }
            int itemcount = int.Parse(_context.Settings.FirstOrDefaultAsync(i => i.Key == "PageItemCount").Result.Value);
            List<Category> categories = await query.Skip((page - 1) * itemcount).Take(itemcount).ToListAsync();
            ViewBag.Status = status;
            return View(PageNatedList<Category>.Create(page, query, itemcount));
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.MainCategories = await _context.Categories.Where(c => c.IsMain && !c.IsDeleted).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            ViewBag.MainCategories = await _context.Categories.Where(c => c.IsMain && !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (category.IsMain && category.FormFile == null)
            {
                ModelState.AddModelError("File", "You should add an image");
                return View();

            }
            else 
            {
                if (category == null || !await _context.Categories.AnyAsync(c => c.IsMain && c.Id == category.ParentId && !c.IsDeleted))
                {
                    ModelState.AddModelError("ParentId", "Not the right main category");
                    return View();
                }

            }
            if (await _context.Categories.AnyAsync(b => b.Name.ToLower().Trim() == category.Name.ToLower().Trim() && !b.IsDeleted))
            {
                ModelState.AddModelError("Name", $"{category.Name} Already Exists");
                return View();
            }
            if (category.FormFile != null)
            {
                if (category.FormFile.CheckFileType("image/*"))
                {
                    ModelState.AddModelError("File", "The uploaded file should be an image (jpg, png, jpeg)");
                    return View();
                }
                if (category.FormFile.CheckFileSize(200))
                {
                    ModelState.AddModelError("File", "The uploaded file should not exceed 200Kb ");
                    return View();
                }
            }
            
            if (category.IsMain)
            {
                category.ParentId = null;
                category.Image = await category.FormFile.CreateAsync(_env, "assets", "images");

            }
            TempData["success"] = "Added Successfully";
            category.CreatedAt = DateTime.UtcNow.AddHours(+4);
            category.Name = category.Name.Trim();
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.MainCategories = await _context.Categories.Where(c => c.IsMain && !c.IsDeleted).ToListAsync();
            
            if (id == null)
            {
                return BadRequest();
            }
            Category dbcategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (dbcategory == null)
            {
                return NotFound();
            }
            return View(dbcategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            ViewBag.MainCategories = await _context.Categories.Where(c => c.IsMain && !c.IsDeleted).ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id == null)
            {
                return BadRequest();
            }
            if (id != category.Id)
            {
                return BadRequest();
            }
            Category dbcategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            List<Category> subs = await _context.Categories.Where(s => s.ParentId == id).ToListAsync();
            if (!category.IsMain)
            {
                if (category.ParentId == null || !await _context.Categories.AnyAsync(c => c.Id == category.ParentId && c.IsMain && !c.IsDeleted))
                {
                    ModelState.AddModelError("ParentId", "There should be a main category");
                    return View(category);
                }
            }
            if (dbcategory == null)
            {
                return NotFound();
            }
            if (await _context.Categories.AnyAsync(c => c.Id != category.Id && c.Name.ToLower() == category.Name.Trim().ToLower()))
            {
                ModelState.AddModelError("Name", "Already Exists");
                return View(category);
            }
            if (category.FormFile != null)
            {
                if (category.FormFile.CheckFileType("image/*"))
                {
                    ModelState.AddModelError("File", "The uploaded file should be an image (jpg, png, jpeg)");
                    return View();
                }
                if (category.FormFile.CheckFileSize(200))
                {
                    ModelState.AddModelError("File", "The uploaded file should not exceed 200Kb ");
                    return View();
                }
                if (dbcategory.Image != null)
                {
                    FileHelper.DeleteFile(_env, dbcategory.Image, "assets", "images");
                }
                dbcategory.Image = await category.FormFile.CreateAsync(_env, "assets", "images");
            }
            if (category.IsMain)
            {
                if (category.FormFile == null)
                {
                    ModelState.AddModelError("Image", "The image should be uploaded");
                    return View(category);
                }
                dbcategory.IsMain = true;
                dbcategory.ParentId = null;
            }
            else
            {
                dbcategory.IsMain = false;
                dbcategory.Image = null;
                dbcategory.ParentId = category.ParentId;
                if (dbcategory.IsMain && dbcategory.Id == category.ParentId)
                {
                    foreach (Category subcategory in subs)
                    {
                        dbcategory.DeletedAt = DateTime.UtcNow.AddHours(+4);
                        category.IsDeleted = true;
                        
                    }
                }
            }
            dbcategory.Name = category.Name.Trim();
            dbcategory.IsUpdated = true;
            dbcategory.UpdatedAt = DateTime.UtcNow.AddHours(+4);
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id, int status , int page)
        {
            ViewBag.Status = status;

            IQueryable<Category> query = _context.Categories.AsQueryable();
            int itemcount =  int.Parse(_context.Settings.FirstOrDefaultAsync(i => i.Key == "PageItemCount").Result.Value);
            if (id == null)
            {
                return BadRequest();
            }
            Category dbcategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id || c.ParentId == id);
            List<Category> subs = await _context.Categories.Where(s => s.ParentId == id).ToListAsync();
            foreach (Category category in subs)
            {
                if (dbcategory.IsMain && dbcategory.Id == category.ParentId)
                {
                    dbcategory.DeletedAt = DateTime.UtcNow.AddHours(+4);
                    category.IsDeleted = true;
                }
            }
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
            dbcategory.IsDeleted = true;
            dbcategory.DeletedAt = DateTime.UtcNow.AddHours(+4);
            _context.SaveChanges();
            return PartialView("_CategoryIndexPartial", PageNatedList<Category>.Create(page, query, itemcount));
        }
        public async Task<IActionResult> Restore(int? id, int status, int page)
        {
            IQueryable<Category> query = _context.Categories.AsQueryable();
            int itemcount = int.Parse(_context.Settings.FirstOrDefaultAsync(i => i.Key == "PageItemCount").Result.Value);
            if (id == null)
            {
                return BadRequest();
            }
            Category dbcategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id || c.ParentId == id);
            //List<Category> subs = await _context.Categories.Where(s => s.ParentId == id).ToListAsync();
            //foreach (Category category in subs)
            //{
            //    if (dbcategory.IsMain && dbcategory.Id == category.ParentId)
            //    {
            //        dbcategory.DeletedAt = DateTime.UtcNow.AddHours(+4);
            //        category.IsDeleted = true;
            //    }
            //}
            if (!dbcategory.IsMain && await _context.Categories.AnyAsync(c=>c.Id == dbcategory.ParentId && c.IsDeleted))
            {
                return BadRequest();
                return PartialView("_CategoryIndexPartial", PageNatedList<Category>.Create(page, query, itemcount));
            }
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

            dbcategory.IsDeleted = false;
            _context.SaveChanges();
            return PartialView("_CategoryIndexPartial", PageNatedList<Category>.Create(page, query, itemcount));
        }
    }
}
