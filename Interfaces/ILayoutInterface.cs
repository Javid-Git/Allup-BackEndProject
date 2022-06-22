using AllUp.ViewModels.BasketViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Interfaces
{
    interface ILayoutInterface
    {
        Task<List<BasketVM>> GetBasket();
        Task<IDictionary<string, string>> GetSetting();
    }
}
