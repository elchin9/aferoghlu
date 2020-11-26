using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.ViewModels
{
    public class CreateProductVM
    {
        public ICollection<IFormFile> AllPhotos { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Size { get; set; }
        public bool IsStock { get; set; }
        [Required]
        public string NameAZ { get; set; }
        [Required]
        public string DescriptionAZ { get; set; }
        [Required]
        public string MaifacturerAZ { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string DescriptionEN { get; set; }
        [Required]
        public string MaifacturerEN { get; set; }
        [Required]
        public string NameRU { get; set; }
        [Required]
        public string DescriptionRU { get; set; }
        [Required]
        public string MaifacturerRU { get; set; }
    }
}
