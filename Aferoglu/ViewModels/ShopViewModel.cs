using Aferoglu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.ViewModels
{
    public class ShopViewModel
    {
        public List<CategoryLang> Categories { get; set; }
        public List<ProductLang> Products { get; set; }
    }
}
