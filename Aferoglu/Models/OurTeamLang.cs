using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.Models
{
    public class OurTeamLang
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Profession { get; set; }
        public int OurTeamId { get; set; }
        public virtual OurTeam OurTeam { get; set; }
        public int LangId { get; set; }
        public virtual Lang Lang { get; set; }
    }
}
