using AllUp.DAL;
using AllUp.Models;
using AllUp.ViewModels.BasketViewModel;
using AllUp.ViewModels.HeaderViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(IDictionary<string, string> settings)
        {
            //IDictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(x => x.Key, x=>x.Value);

            List<BasketVM> basketVMs = null;
            string basket = HttpContext.Request.Cookies["basket"];
            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

                foreach (BasketVM basketVM in basketVMs)
                {
                    Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProdId);

                    basketVM.Name = product.Name;
                    basketVM.Image = product.MainImnage;
                    basketVM.Price = product.DicountedPrice > 0 ? product.DicountedPrice : product.Price;
                    basketVM.ExTax = product.ExTax;
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }
            HeaderVM headerVMs = new HeaderVM()
            {
                Settings = settings,
                BasketVMs = basketVMs
            };

            return View(await Task.FromResult(headerVMs));
        }
    }
}
