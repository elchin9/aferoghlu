using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aferoglu.Models
{
    public class Lang
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Code { get; set; }
        public virtual ICollection<SliderLang> SliderLangs { get; set; } = new HashSet<SliderLang>();
        public virtual ICollection<AboutLang> AboutLangs { get; set; } = new HashSet<AboutLang>();
        public virtual ICollection<AferogluHistoryLang> AferogluHistoryLangs { get; set; } = new HashSet<AferogluHistoryLang>();
        public virtual ICollection<CategoryLang> CategoryLangs { get; set; } = new HashSet<CategoryLang>();
        public virtual ICollection<OurTeamLang> OurTeamLangs { get; set; } = new HashSet<OurTeamLang>();
        public virtual ICollection<ProductLang> ProductLangs { get; set; } = new HashSet<ProductLang>();
        public virtual ICollection<StaticDataLang> StaticDataLangs { get; set; } = new HashSet<StaticDataLang>();
        public virtual ICollection<TestimonialsLang> TestimonialsLangs { get; set; } = new HashSet<TestimonialsLang>();


    }
}
