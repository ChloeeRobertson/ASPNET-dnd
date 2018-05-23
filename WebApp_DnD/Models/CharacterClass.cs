using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_DnD.Models
{
    public class CharacterClass
    {
        [Key]
        public string Name { get; set; }
        public string HitDie { get; set; }
        public string Discription { get; set; }

        [ForeignKey("HitDie")]
        public Die Die { get; set; }
    }
}
