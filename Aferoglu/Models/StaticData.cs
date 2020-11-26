using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class StaticData
    {
        public int Id { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        [Required]
        public string PhoneNumberOne { get; set; }

        public string PhoneNumberTwo { get; set; }

        [Required]
        public string EmailAdress { get; set; }

        public string Map { get; set; }
        public virtual ICollection<StaticDataLang> StaticDataLangs { get; set; } = new HashSet<StaticDataLang>();

    }
}
