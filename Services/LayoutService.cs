using AllUp.DAL;
using AllUp.Interfaces;
using AllUp.Models;
using AllUp.ViewModels.BasketViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Services
{
    public class LayoutService : ILayoutInterface
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;
        public LayoutService(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;

        }

        public async Task<List<BasketVM>> GetBasket()
        {
            string basket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            
            foreach (BasketVM basketVM in basketVMs)
            {
                Product dbproduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == basketVM.ProdId);

                basketVM.Name = dbproduct.Name;
                basketVM.Price = dbproduct.DicountedPrice > 0 ? dbproduct.DicountedPrice : dbproduct.Price;
                basketVM.ExTax = dbproduct.ExTax;
                basketVM.Image = dbproduct.MainImnage;
            };


            return basketVMs;
        }

        public async Task<IDictionary<string, string>> GetSetting()
        {
            IDictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(x => x.Key, x => x.Value);

            return settings;
        }
    }
}
