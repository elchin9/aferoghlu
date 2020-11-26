using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class TestimonialsLang
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string FullName { get; set; }
        public int TestimonialsId { get; set; }
        public virtual Testimonials Testimonials { get; set; }
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}
