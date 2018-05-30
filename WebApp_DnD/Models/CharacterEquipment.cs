using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_DnD.Models
{
    public class CharacterEquipment
    {
        public string User { get; set; }
        public string Name { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }



        public Character AppUser { get; set; }
    }
}
