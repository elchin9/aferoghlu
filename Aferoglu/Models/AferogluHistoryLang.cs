using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class AferogluHistoryLang
    {
        public int Id { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string Description { get; set; }
        public int AferogluHistoryId { get; set; }
        public virtual AferogluHistory AferogluHistory { get; set; }
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}
