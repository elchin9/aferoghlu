using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.ViewModels
{
    public class CreateHistoryVM
    {
        public IFormFile Photo { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string HeaderAZ { get; set; }
        [Required]
        public string DescriptionAZ { get; set; }
        [Required]
        public string HeaderEN { get; set; }
        [Required]
        public string DescriptionEN { get; set; }
        [Required]
        public string HeaderRU { get; set; }
        [Required]
        public string DescriptionRU { get; set; }
    }
}
