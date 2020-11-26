using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class AferogluHistory
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        [Required]
        public string Date { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public virtual ICollection<AferogluHistoryLang> AferogluHistoryLangs { get; set; } = new HashSet<AferogluHistoryLang>();

    }
}
