using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class StaticDataLang
    {
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        public string WorkingHours { get; set; }
        public int StaticDataId { get; set; }
        public virtual StaticData StaticData { get; set; }
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}
