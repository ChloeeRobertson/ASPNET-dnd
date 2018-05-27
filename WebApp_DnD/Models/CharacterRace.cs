using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_DnD.Models
{
    public class CharacterRace
    {
        [Key]
        public string Name { get; set; }
        public string Discription { get; set; }

    }
}
