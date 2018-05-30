using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_DnD.Models
{
    public class Character
    {
        public string User { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }

        public string Class { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }

        [Range(1,20)]
        public int Strength { get; set; }
        [Range(1, 20)]
        public int Dexterity { get; set; }
        [Range(1, 20)]
        public int Consitution { get; set; }
        [Range(1, 20)]
        public int Intelligence { get; set; }
        [Range(1, 20)]
        public int Wisdom { get; set; }
        [Range(1, 20)]
        public int Charisma { get; set; }

        [ForeignKey("User")]
        public ApplicationUser AppUser { get; set; }

        [ForeignKey("Class")]
        public CharacterClass CharClass { get; set; }

        [ForeignKey("Race")]
        public CharacterRace CharRace { get; set; }

        [ForeignKey("Alignment")]
        public Alignment CharAlign { get; set; }
    }
}
