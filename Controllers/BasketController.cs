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
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddToBasket(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }
            string basket = HttpContext.Request.Cookies["basket"];
            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }
            if (basketVMs.Exists(b => b.ProdId == id))
            {
                basketVMs.Find(b => b.ProdId == id).SelectCount++;
            }
            else
            {
                BasketVM basketVM = new BasketVM
                {
                    ProdId = product.Id,
                    SelectCount = 1
                };

                basketVMs.Add(basketVM);
            }

            basket = JsonConvert.SerializeObject(basketVMs);
            HttpContext.Response.Cookies.Append("basket", basket);
            
            
            
            return PartialView("_AddToCartPartial",  await _basketProduct(basketVMs));
        }
        public async Task<IActionResult> DeleteFromBasket(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }
            string basket = HttpContext.Request.Cookies["basket"];
            List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            if (string.IsNullOrWhiteSpace(basket)) return BadRequest();

            BasketVM basketVM = basketVMs.Find(b => b.ProdId == id);
            if (basket == null) return NotFound();

            basketVMs.Remove(basketVM);

            basket = JsonConvert.SerializeObject(basketVMs);
            HttpContext.Response.Cookies.Append("basket", basket);

            return PartialView("_AddToCartPartial", await _basketProduct(basketVMs));

        }
        private async Task<List<BasketVM>> _basketProduct(List<BasketVM> basketVMs)
        {

            foreach (BasketVM item in basketVMs)
            {
                Product dbproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.ProdId);

                item.Name = dbproduct.Name;
                item.Price = dbproduct.DicountedPrice > 0 ? dbproduct.DicountedPrice : dbproduct.Price;
                item.ExTax = dbproduct.ExTax;
                item.Image = dbproduct.MainImnage;
            };
            return basketVMs;
        }
    }
}
