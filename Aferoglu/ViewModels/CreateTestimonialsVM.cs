using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.ViewModels
{
    public class CreateTestimonialsVM
    {
        public IFormFile Photo { get; set; }
        [Required]
        public string DescriptionAZ { get; set; }
        [Required]
        public string FullNameAZ { get; set; }
        [Required]
        public string DescriptionEN { get; set; }
        [Required]
        public string FullNameEN { get; set; }
        [Required]
        public string DescriptionRU { get; set; }
        [Required]
        public string FullNameRU { get; set; }
    }
}
