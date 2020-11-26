using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class ProductLang
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Maifacturer { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}
