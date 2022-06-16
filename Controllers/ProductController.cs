using AllUp.DAL;
using AllUp.Models;
using AllUp.ViewModels.BasketViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product product = await _context.Products.Include(p=>p.Photos).Include(b=>b.Brand).Include(pt=>pt.ProductTags).ThenInclude(t=>t.Tag).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public async Task<IActionResult> ModalDetail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product product = await _context.Products.Include(p => p.Photos).Include(b => b.Brand).Include(pt => pt.ProductTags).ThenInclude(t => t.Tag).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return PartialView("_ModalDetailPartial", product);
        }
        public async Task<IActionResult> Search(string search)
        {
            List<Product> products = await _context.Products.Where(p => p.Name.ToLower().Contains(search.ToLower()) || 
            p.Brand.Name.ToLower().Contains(search.ToLower()) || 
            p.ProductTags.Any(pt=>pt.Tag.Name.ToLower().Contains(search.ToLower()))).ToListAsync();
            return PartialView("_SearchPartial", products);
        }

    }
}
