using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp_DnD.Models;

namespace WebApp_DnD.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Die> Dice { get; set; }
        public DbSet<CharacterRace> CharacterRaces { get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<Alignment> Alignments { get; set; }
        public DbSet<Character> Characters { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Die>().ToTable("Die");
            builder.Entity<CharacterRace>().ToTable("CharacterRace");
            builder.Entity<CharacterClass>().ToTable("CharacterClass");
            builder.Entity<Alignment>().ToTable("Alignment");

            builder.Entity<Character>().ToTable("Characters").HasKey(c => new {c.User, c.Name });
        }
    }
}
