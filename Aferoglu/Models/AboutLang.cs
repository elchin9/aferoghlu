using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aferoglu.Models
{
    public class AboutLang
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int AboutId { get; set; }
        public virtual About About { get; set; }
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}
