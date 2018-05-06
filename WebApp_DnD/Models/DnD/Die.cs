using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_DnD.Models.DnD
{
    public class Die
    {
        [Key]
        public string Type { get; set; }
        public int NumSides { get; set; }
    }
}
