using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class MailBox
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad/Soyad boş qala bilməz."), StringLength(100, ErrorMessage = "Ad/Soyad 100 simvoldan çox ola bilməz.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E-mail adresiniz boş qala bilməz."), EmailAddress(ErrorMessage = "Düzgün email adresi istifadə edin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon nömrəniz boş qala bilməz"), Phone(ErrorMessage = "Düzgün nömrə istifadə edin")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mesajınız boş qala bilməz")]
        public string TextBody { get; set; }

        public DateTime Time { get; set; }
    }
}
