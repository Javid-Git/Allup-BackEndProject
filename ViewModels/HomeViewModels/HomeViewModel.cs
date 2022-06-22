using AllUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.ViewModels.HomeViewModels
{
    public class HomeViewModel
    {
        public List<Product> Products{ get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Product> BestSeller { get; set; }
        public List<Product> Featured { get; set; }
        public List<Product> NewArrival { get; set; }
    }
}
