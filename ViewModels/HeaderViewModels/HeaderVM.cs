using AllUp.ViewModels.BasketViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.ViewModels.HeaderViewModels
{
    public class HeaderVM
    {
        public IDictionary<string,string> Settings { get; set; }
        public List<BasketVM> BasketVMs{ get; set; }
    }
}
