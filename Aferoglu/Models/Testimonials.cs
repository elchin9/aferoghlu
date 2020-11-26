using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class Testimonials
    {
        public int Id { get; set; }

        public string PhotoURL { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public virtual ICollection<TestimonialsLang> TestimonialLangs { get; set; } = new HashSet<TestimonialsLang>();

    }
}
