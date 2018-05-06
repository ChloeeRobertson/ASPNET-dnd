using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_DnD.Models.DnD;

namespace WebApp_DnD.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context) {

            context.Database.EnsureCreated();

            List<Die> dice = new List<Die>()
                {
                    new Die {Type = "d4", NumSides = 4},
                    new Die {Type = "d6", NumSides = 6},
                    new Die {Type = "d8", NumSides = 8},
                    new Die {Type = "d10", NumSides = 10},
                    new Die {Type = "d12", NumSides = 12},
                    new Die {Type = "d20", NumSides = 20},
            };

            context.Dice.AddRange(dice);
            context.SaveChanges();

        }
    }
}
