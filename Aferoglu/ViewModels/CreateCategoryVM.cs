using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.ViewModels
{
    public class CreateCategoryVM
    {
        public IFormFile Photo { get; set; }
        [Required]
        public string NameAZ { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string NameRU { get; set; }
    }
}
