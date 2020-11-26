using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.ViewModels
{
    public class CreateTeamVM
    {
        public IFormFile Photo { get; set; }
        [Required]
        public string FullNameAZ { get; set; }
        [Required]
        public string ProfessionAZ { get; set; }
        [Required]
        public string FullNameEN { get; set; }
        [Required]
        public string ProfessionEN { get; set; }
        [Required]
        public string FullNameRU { get; set; }
        [Required]
        public string ProfessionRU { get; set; }
    }
}
