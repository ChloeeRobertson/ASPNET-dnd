using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_DnD.Models
{
    public class Character
    {
        public string User { get; set; }
        public string Name { get; set; }

        public string Class { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }

        [ForeignKey("user")]
        public ApplicationUser AppUser { get; set; }

        [ForeignKey("Class")]
        public CharacterClass CharClass { get; set; }

        [ForeignKey("Race")]
        public CharacterRace CharRace { get; set; }

        [ForeignKey("Alignment")]
        public Alignment CharAlign { get; set; }
    }
}
