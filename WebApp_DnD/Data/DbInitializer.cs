using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_DnD.Models;

namespace WebApp_DnD.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context) {

            context.Database.EnsureCreated();

            if (!context.Dice.Any()) {
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


            if (!context.CharacterRaces.Any()) {
                List<CharacterRace> races = new List<CharacterRace>() {
                    new CharacterRace {Name="Dragonborn", Discription="Dragonborn look very much like dragons standing erect in humanoid form, though they lack wings or a tail."},
                    new CharacterRace {Name="Dwarf", Discription="Bold and hardy, dwarves are known as skilled warriors, miners, and workers of stone and metal."},
                    new CharacterRace {Name="Elf", Discription="Elves are a magical people of otherworldly grace, living in the world but not entirely part of it."},
                    new CharacterRace {Name="Gnome", Discription="A gnome’s energy and enthusiasm for living shines through every inch of his or her tiny body."},
                    new CharacterRace {Name="Half-Elf", Discription="Half-elves combine what some say are the best qualities of their elf and human parents."},
                    new CharacterRace {Name="Halfling", Discription="The diminutive halflings survive in a world full of larger creatures by avoiding notice or, barring that, avoiding offense."},
                    new CharacterRace {Name="Human", Discription="Humans are the most adaptable and ambitious people among the common races. Whatever drives them, humans are the innovators, the achievers, and the pioneers of the worlds."},
                    new CharacterRace {Name="Tiefling", Discription="To be greeted with stares and whispers, to suffer violence and insult on the street, to see mistrust and fear in every eye: this is the lot of the tiefling"},
                };

                context.CharacterRaces.AddRange(races);
                context.SaveChanges();
            }


            if (!context.CharacterClasses.Any()) {
                List<CharacterClass> classes = new List<CharacterClass>() {
                    new CharacterClass {Name="Barbarian", HitDie="d12", Discription="A fierce warrior of primitive background who can enter a battle rage"},
                    new CharacterClass {Name="Bard", HitDie="d8", Discription="An inspiring magician whose power echoes the music of creation"},
                    new CharacterClass {Name="Cleric", HitDie="d8", Discription="A priestly champion who wields divine magic in service of a higher power"},
                    new CharacterClass {Name="Druid", HitDie="d8", Discription="A priest of the Old Faith, wielding the powers of nature and adopting animal forms"},
                    new CharacterClass {Name="Fighter", HitDie="d10", Discription="A master of martial combat, skilled with a variety of weapons and armor"},
                    new CharacterClass {Name="Monk", HitDie="d8", Discription="A master of martial arts, harnessing the power of the body in pursuit of physical and spiritual perfection"},
                    new CharacterClass {Name="Paladin", HitDie="d10", Discription="A holy warrior bound to a sacred oath"},
                    new CharacterClass {Name="Ranger", HitDie="d10", Discription="A warrior who combats threats on the edges of civilization"},
                    new CharacterClass {Name="Rogue", HitDie="d8", Discription="A scoundrel who uses stealth and trickery to overcome obstacles and enemies"},
                    new CharacterClass {Name="Sorcerer", HitDie="d6", Discription="A spellcaster who draws on inherent magic from a gift or bloodline"},
                    new CharacterClass {Name="Warlock", HitDie="d8", Discription="A wielder of magic that is derived from a bargain with an extraplanar entity"},
                    new CharacterClass {Name="Wizard", HitDie="d6", Discription="A scholarly magic-user capable of manipulating the structures of reality"},
                };

                context.CharacterClasses.AddRange(classes);
                context.SaveChanges();
            }
        }
    }
}
