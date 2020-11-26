using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<CategoryLang> CategoryLangs { get; set; } = new HashSet<CategoryLang>();

    }
}
