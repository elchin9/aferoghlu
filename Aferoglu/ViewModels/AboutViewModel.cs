using Aferoglu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.ViewModels
{
    public class AboutViewModel
    {
        public List<AferogluHistoryLang> History { get; set; }
        public List<OurTeamLang> Teams { get; set; }
        public AboutLang AboutLang { get; set; }
        public List<TestimonialsLang> Testimonials { get; set; }
    }
}
