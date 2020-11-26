using Aferoglu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.ViewModels
{
    public class HomeViewModel
    {
        public List<SliderLang> Slider { get; set; }
        public List<CategoryLang> Category { get; set; }
        public List<ProductLang> Products { get; set; }
        public AboutLang Abouts { get; set; }
        public List<OurTeamLang> OurTeam { get; set; }

    }
}
