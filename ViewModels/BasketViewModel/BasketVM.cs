﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.ViewModels.BasketViewModel
{
    public class BasketVM
    {
        public int ProdId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int SelectCount { get; set; }
        public double ExTax { get; set; }
    }
}
