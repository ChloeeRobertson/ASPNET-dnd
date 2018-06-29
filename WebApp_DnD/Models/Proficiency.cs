using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_DnD.Models
{
    public class Proficiency
    {
        public string User { get; set; }
        public string Name { get; set; }
        public string ProficiencyName { get; set; }



        public Character AppUser { get; set; }
    }
}
