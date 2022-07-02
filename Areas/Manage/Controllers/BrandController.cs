using AllUp.DAL;
using AllUp.Models;
using AllUp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        public BrandController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? status, int page=1)
        {
         
            IQueryable<Brand> query = _context.Brands.AsQueryable();
            if (status != null && status > 0 )
            {
                if (status == 1)
                {
                    query = _context.Brands.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    query = _context.Brands.Where(b => !b.IsDeleted);
                }
            }
            int itemcount = int.Parse(_context.Settings.FirstOrDefaultAsync(i => i.Key == "PageItemCount").Result.Value);
            List<Brand> brands = await query.Skip((page - 1) * itemcount).Take(itemcount).ToListAsync();
            //ViewBag.PageCount = (int)Math.Ceiling((decimal)query.Count() / itemcount);
            ViewBag.Status = status;
            //ViewBag.Page = page;
            //ViewBag.ItemCountInPage = itemcount;
            return View(PageNatedList<Brand>.Create(page, query, itemcount));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (await _context.Brands.AnyAsync(b => b.Name.ToLower().Trim() == brand.Name.ToLower().Trim() && !b.IsDeleted))
            {
                ModelState.AddModelError("Name", $"{brand.Name} Already Exists");
                return View();
            }
            TempData["success"] = "Added Successfully";
            brand.CreatedAt = DateTime.UtcNow.AddHours(+4);
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Brand dbbrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (dbbrand == null)
            {
                return NotFound();
            }
            return View(dbbrand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Brand brand)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (id != brand.Id)
            {
                return BadRequest();
            }
            Brand dbbrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (dbbrand == null)
            {
                return NotFound();
            }
            if (await _context.Brands.AnyAsync(b => b.Id != brand.Id && !b.IsDeleted && b.Name.ToLower().Trim() == brand.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"{brand.Name} Alreade Exists");
                return View();
            }
            TempData["success"] = "Updated Successfully";

            dbbrand.Name = brand.Name;
            dbbrand.IsUpdated = true;
            dbbrand.UpdatedAt = DateTime.UtcNow.AddHours(+4);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id, int? status, int page)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            Brand dbbrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (dbbrand == null)
            {
                return NotFound();
            }

            dbbrand.IsDeleted = true;
            dbbrand.DeletedAt = DateTime.UtcNow.AddHours(+4);

            await _context.SaveChangesAsync();
            IQueryable<Brand> brands = _context.Brands.AsQueryable();
            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    brands = brands.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    brands = brands.Where(b => !b.IsDeleted);
                }
            }
            ViewBag.Status = status;
            int itemcount = int.Parse(_context.Settings.FirstOrDefaultAsync(i => i.Key == "PageItemCount").Result.Value);

            return PartialView("_BrandIndexPartial", PageNatedList<Brand>.Create(page, brands, itemcount));
        }
        public async Task<IActionResult> Restore(int? id, int? status, int page )
        {
            if (id == null)
            {
                return BadRequest();
            }

            Brand dbbrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (dbbrand == null)
            {
                return NotFound();
            }

            dbbrand.IsDeleted = false;
            dbbrand.DeletedAt = DateTime.UtcNow.AddHours(+4);

            await _context.SaveChangesAsync();
            IQueryable<Brand> brands = _context.Brands.AsQueryable();
            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    brands = brands.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    brands = brands.Where(b => !b.IsDeleted);
                }
            }
            int itemcount = int.Parse(_context.Settings.FirstOrDefaultAsync(i => i.Key == "PageItemCount").Result.Value);

            ViewBag.Status = status;
            return PartialView("_BrandIndexPartial", PageNatedList<Brand>.Create(page, brands, itemcount));
        }
    }
}
