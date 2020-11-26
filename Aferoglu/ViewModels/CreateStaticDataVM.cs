using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.ViewModels
{
    public class CreateStaticDataVM
    {
        [Required]
        public string AddressAZ { get; set; }
        public string WorkingHoursAZ { get; set; }
        [Required]
        public string AddressEN { get; set; }
        public string WorkingHoursEN { get; set; }
        [Required]
        public string AddressRU { get; set; }
        public string WorkingHoursRU { get; set; }
        public string Facebook { get; set; }

        public string Instagram { get; set; }

        [Required]
        public string PhoneNumberOne { get; set; }

        public string PhoneNumberTwo { get; set; }

        [Required]
        public string EmailAdress { get; set; }

        public string Map { get; set; }
    }
}
