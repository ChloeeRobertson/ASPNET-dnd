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

        

        [ForeignKey("User")]
        public ApplicationUser AppUser { get; set; }

        [ForeignKey("Class")]
        public CharacterClass CharClass { get; set; }

        [ForeignKey("Race")]
        public CharacterRace CharRace { get; set; }

        [ForeignKey("Alignment")]
        public Alignment CharAlign { get; set; }


        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int MaxHitPoints { get; set; }

        public int Inspiration { get; set; }
        public int ProficiencyBonus { get; set; }

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

        //Saving Throws
        public int ST_Strength { get; set; }
        public int ST_Dexterity { get; set; }
        public int ST_Consitution { get; set; }
        public int ST_Intelligence { get; set; }
        public int ST_Wisdom { get; set; }
        public int ST_Charisma { get; set; }

        //Skills
        public int Acrobatics { get; set; }
        public int AnimalHandling { get; set; }
        public int Arcana { get; set; }
        public int Athletics { get; set; }
        public int Deception { get; set; }
        public int History { get; set; }
        public int Insight { get; set; }
        public int Intimidation { get; set; }
        public int Investigation { get; set; }
        public int Medicine { get; set; }
        public int Nature { get; set; }
        public int Perception { get; set; }
        public int Performance { get; set; }
        public int Persuasion { get; set; }
        public int Religion { get; set; }
        public int SleightOfHand { get; set; }
        public int Stealth { get; set; }
        public int Survival { get; set; }

        public IEnumerable<CharacterEquipment> Equipment { get; set; }
        public IEnumerable<Proficiency> Proficiency { get; set; }
    }
}
