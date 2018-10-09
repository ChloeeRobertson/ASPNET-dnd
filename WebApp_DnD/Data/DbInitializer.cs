using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp_DnD.Models;
using System.Drawing;

namespace WebApp_DnD.Data
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager) {

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


            if (!context.Alignments.Any()) {
                List<Alignment> alignments = new List<Alignment>() {
                    new Alignment {AlignmentCode = "LG", Name="Lawful Good", Description="creatures can be counted on to do the right thing as expected by society. Gold dragons, paladins, and most dwarves are lawful good."},
                    new Alignment {AlignmentCode = "LN", Name="Lawful Neutral", Description="individuals act in accordance with law, tradition, or personal codes. Many monks and some wizards are lawful neutral."},
                    new Alignment {AlignmentCode = "LE", Name="Lawful Evil", Description="creatures methodically take what they want, within the limits of a code of tradition, loyalty, or order. Devils, blue dragons, and hobgoblins are Lawful evil."},
                    new Alignment {AlignmentCode = "NG", Name="Neutral Good", Description="folk do the best they can to help others according to their needs. Many celestials, some cloud giants, and most gnomes are neutral good."},
                    new Alignment {AlignmentCode = "N", Name="Neutral", Description="is the alignment of those who prefer to steer clear of moral questions and don't take sides, doing what seems best at the time. Lizardfolk, most druids, and many humans are neutral."},
                    new Alignment {AlignmentCode = "NE", Name="Neutral Evil", Description="is the alignment of those who do whatever they can get away with, without compassion or qualms. Many drow, some cloud giants, and yugoloths are neutraI evil."},
                    new Alignment {AlignmentCode = "CG", Name="Chaotic Good", Description="creatures act as their conscience directs, with little regard for what others expect. Copper dragons, many elves, and unicorns are chaotic good."},
                    new Alignment {AlignmentCode = "CN", Name="Chaotic Neutral", Description="creatures follow their whims, holding their personal freedom above all else. Many barbarians and rogues, and some bards, are chaotic neutral."},
                    new Alignment {AlignmentCode = "CE", Name="Chaotic Evil", Description="creatures act with arbitrary violence, spurred by their greed, hatred, or bloodlust. Demons, red dragons, and orcs are chaotic evil."},
                };

                context.Alignments.AddRange(alignments);
                context.SaveChanges();
            }


            //Users
            string password = "P@$$w0rd";

            if (await userManager.FindByNameAsync("c@c.c") == null) {
                var user = new ApplicationUser {
                    UserName = "c@c.c",
                    Email = "c@c.c"
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded) {
                    await userManager.AddPasswordAsync(user, password);
                }
            }

            var chloee = await userManager.FindByEmailAsync("c@c.c");
            string path = Directory.GetCurrentDirectory();
            Byte[] test = File.ReadAllBytes(path + "\\wwwroot\\images\\taako.jpg");
            
            if (!context.Characters.Any()) {
                List<Character> characters = new List<Character>() {
                    new Character{User= chloee.Id,
                        Name ="Lou-Lou",
                        Class ="Rogue",
                        Race ="Elf",
                        Alignment ="CG",
                        ExperiencePoints = 100,
                        Level = 1,},
                    new Character{User= chloee.Id,
                        Name ="Taako",
                        Class ="Wizard",
                        Race ="Elf",
                        Alignment ="CG",
                        ExperiencePoints = 100,
                        Level = 1,
                        Picture =  File.ReadAllBytes(path + "\\wwwroot\\images\\taako.jpg"),
                        Strength = 10,
                        Dexterity = 15,
                        Consitution = 14,
                        Intelligence = 16,
                        Wisdom = 12,
                        Charisma = 8,
                        Inspiration = 1,
                        ProficiencyBonus = 2,
                        ArmorClass = 12,
                        Initiative =  2,
                        Speed = 20,
                        //Saving Throws
                        ST_Strength = 0,
                        ST_Dexterity = 2,
                        ST_Consitution = 2,
                        ST_Intelligence = 5,
                        ST_Wisdom = 3,
                        ST_Charisma = -1,
                        //Skills
                        Acrobatics = 2,
                        AnimalHandling = 1,
                        Arcana = 5,
                        Athletics = 0,
                        Deception = -1,
                        History = 3,
                        Insight = 3,
                        Intimidation = -1,
                        Investigation = 5,
                        Medicine = 1,
                        Nature = 3,
                        Perception = 3,
                        Performance = -1,
                        Persuasion = -1,
                        Religion = 5,
                        SleightOfHand = 2,
                        Stealth = 2,
                        Survival = 1},
                    new Character{User= chloee.Id,
                        Name ="Magnus Burnsides",
                        Class ="Fighter",
                        Race ="Human",
                        Alignment ="LG",
                        ExperiencePoints = 100,
                        Level = 1,
                        Picture =  File.ReadAllBytes(path + "\\wwwroot\\images\\magnus.jpg"),
                        Strength = 16,
                        Dexterity = 14,
                        Consitution = 15,
                        Intelligence = 10,
                        Wisdom = 8,
                        Charisma = 12,
                        Inspiration = 1,
                        ProficiencyBonus = 2,
                        ArmorClass = 17,
                        Initiative =  2,
                        Speed = 30,
                        //Saving Throws
                        ST_Strength = 5,
                        ST_Dexterity = 2,
                        ST_Consitution = 4,
                        ST_Intelligence = 0,
                        ST_Wisdom = -1,
                        ST_Charisma = 1,
                        //Skills
                        Acrobatics = 2,
                        AnimalHandling = 2,
                        Arcana = 0,
                        Athletics = 5,
                        Deception = 1,
                        History = 0,
                        Insight = -1,
                        Intimidation = 3,
                        Investigation = 0,
                        Medicine = -1,
                        Nature = 0,
                        Perception = -1,
                        Performance = 1,
                        Persuasion = 1,
                        Religion = 0,
                        SleightOfHand = 2,
                        Stealth = 2,
                        Survival = 1},
                    new Character{User= chloee.Id,
                        Name ="Merle Highchurch",
                        Class ="Cleric",
                        Race ="Dwarf",
                        Alignment ="LG",
                        ExperiencePoints = 100,
                        Level = 1,
                        Picture =  File.ReadAllBytes(path + "\\wwwroot\\images\\merle.jpg")},
                };
                context.Characters.AddRange(characters);
                context.SaveChanges();
            }

            if (!context.CharacterEquipment.Any()) {
                List<CharacterEquipment> characterEquipments = new List<CharacterEquipment>() {
                    new CharacterEquipment{User= chloee.Id, Name="Taako", ItemName="Umbra-Staff", Description="A Magical umbrella"},
                    new CharacterEquipment{User= chloee.Id, Name="Taako", ItemName="Wand of Switcheroo", Description="When pointed at another creature of similar size within 100 feet and activated the holder will switch places with the target if it is willing. If the target is unwilling it must succeed a DC 17 Constitution saving throw to remain in place. Holds 3 charges, regains one charge after a long rest."},
                    new CharacterEquipment{User= chloee.Id, Name="Taako", ItemName="Flaming Poisoning Raging Sword Of Doom", Description="It features a gigantic blade wreathed in flames with a crooked, oozing scorpion’s stinger affixed to its point. Deals an extra 20 melee damage."},
                    new CharacterEquipment{User= chloee.Id, Name="Taako", ItemName="Stone of Farspeech", Description="Basically a fantasy walkie-talkie or, if you prefer, a fantasy smartphone."},

                    new CharacterEquipment{User= chloee.Id, Name="Merle Highchurch", ItemName="Phone-a-Friend Scrybones", Description="The Scrybones enable the bearer to ask the Dungeon Master (Griffin) a yes-or-no question once per day."},
                    new CharacterEquipment{User= chloee.Id, Name="Merle Highchurch", ItemName="Extreme Teen Bible", Description="The Extreme Teen Bible is a +1 holy symbol featuring a rad skateboarder on its cover. It allows the user to more easily spread the work of Pan to teens.."},
                    new CharacterEquipment{User= chloee.Id, Name="Merle Highchurch", ItemName="Nitpicker", Description="The Nitpicker is a highly sarcastic, cantankerous humanoid resembling a garden gnome. Twice a day, it can be brought into the presence of a lock, wherein it becomes animated and picks the lock. While working, the Nitpicker criticizes the members of the party on their recent performance in the campaign."},
                    new CharacterEquipment{User= chloee.Id, Name="Merle Highchurch", ItemName="Stone of Farspeech", Description="Basically a fantasy walkie-talkie or, if you prefer, a fantasy smartphone."},

                    new CharacterEquipment{User= chloee.Id, Name="Magnus Burnsides", ItemName="Rail Splitter", Description="An ax offers +1 to attack and damage rolls, as well as the ability to fell any tree once per day."},
                    new CharacterEquipment{User= chloee.Id, Name="Magnus Burnsides", ItemName="Stone of Farspeech", Description="Basically a fantasy walkie-talkie or, if you prefer, a fantasy smartphone."},
                    new CharacterEquipment{User= chloee.Id, Name="Magnus Burnsides", ItemName="Lens of straight creepin'", Description="Allows the user to find footprints, tracks or markings of any person or thing that traveled through the area recently once per day."},
                    new CharacterEquipment{User= chloee.Id, Name="Magnus Burnsides", ItemName="Gluttons Fork", Description="Once a day, this fork will allow the user to eat any non-magical item they can fit in their mouth and gain 2 d6 points of health. Just tap the fork on the item and it will turn edible."},
                };
                context.CharacterEquipment.AddRange(characterEquipments);
                context.SaveChanges();
            }

            if (!context.Proficiencies.Any()) {
                List<Proficiency> proficiency = new List<Proficiency>() {
                    new Proficiency{User= chloee.Id, Name="Taako", ProficiencyName="Daggers", },
                    new Proficiency{User= chloee.Id, Name="Taako", ProficiencyName="Darts", },
                    new Proficiency{User= chloee.Id, Name="Taako", ProficiencyName="Longbows", },
                    new Proficiency{User= chloee.Id, Name="Taako", ProficiencyName="Longswords", },
                    new Proficiency{User= chloee.Id, Name="Taako", ProficiencyName="Quartershaft", },
                    new Proficiency{User= chloee.Id, Name="Taako", ProficiencyName="Shortbows", },
                    new Proficiency{User= chloee.Id, Name="Taako", ProficiencyName="Shortswords", },
                    new Proficiency{User= chloee.Id, Name="Taako", ProficiencyName="Sling", },
                    new Proficiency{User= chloee.Id, Name="Magnus Burnsides", ProficiencyName="Animal Handling", },
                    new Proficiency{User= chloee.Id, Name="Magnus Burnsides", ProficiencyName="vehicles", },
                    new Proficiency{User= chloee.Id, Name="Merle Highchurch", ProficiencyName="shortsword", },
                    new Proficiency{User= chloee.Id, Name="Merle Highchurch", ProficiencyName="Religion", },

                };
                context.Proficiencies.AddRange(proficiency);
                context.SaveChanges();
            }
        }
    }
}
