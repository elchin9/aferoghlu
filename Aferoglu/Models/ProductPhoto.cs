using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class ProductPhoto
    {
        public int Id { get; set; }

        public string PhotoURL { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
