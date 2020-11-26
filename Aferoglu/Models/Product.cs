using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Size { get; set; }
        public bool IsStock { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductPhoto> Photos { get; set; }
        public virtual ICollection<ProductLang> ProductLangs { get; set; } = new HashSet<ProductLang>();

        [NotMapped]
        public ICollection<IFormFile> AllPhotos { get; set; }
    }
}
