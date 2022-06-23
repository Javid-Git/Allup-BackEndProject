using AllUp.DAL;
using AllUp.Models;
using AllUp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
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
            //ViewBag.PageCount = (int)Math.Ceiling((decimal)query.Count() / itemcount);
            ViewBag.Status = status;
            //ViewBag.Page = page;
            //ViewBag.ItemCountInPage = itemcount;
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
            if (category.IsMain && category.Image == null)
            {
                ModelState.AddModelError("Image", $"You should add an image");
                return View();

            }
            else 
            {
                if (category == null || !await _context.Categories.AnyAsync(c => c.IsMain && c.Id == category.Id && !c.IsDeleted))
                {
                    ModelState.AddModelError("ParentId", $"Not the right main category");
                    return View();
                }

            }
            if (await _context.Categories.AnyAsync(b => b.Name.ToLower().Trim() == category.Name.ToLower().Trim() && !b.IsDeleted))
            {
                ModelState.AddModelError("Name", $"{category.Name} Already Exists");
                return View();
            }

            TempData["success"] = "Added Successfully";
            category.CreatedAt = DateTime.UtcNow.AddHours(+4);
            category.Name = category.Name.Trim();
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
