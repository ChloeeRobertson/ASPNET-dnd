using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_DnD.Models
{
    public class Alignment
    {
        [Key]
        public string AlignmentCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
