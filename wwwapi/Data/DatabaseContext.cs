using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using wwwapi.Models;
using wwwapi.Models.Users;

namespace wwwapi.Data
{
    public class DatabaseContext : IdentityUserContext<User>
    {

        private string _connectionString;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            //this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // auto include for getting all information though character
            modelBuilder.Entity<Character>().Navigation(c => c.Abilities).AutoInclude();
            modelBuilder.Entity<Character>().Navigation(c => c.Skills).AutoInclude();
            modelBuilder.Entity<Character>().Navigation(c => c.Speed).AutoInclude();
            modelBuilder.Entity<Character>().Navigation(c => c.Style).AutoInclude();
            modelBuilder.Entity<Character>().Navigation(c => c.HitPoints).AutoInclude();

            // auto include for getting all information through abilities
            modelBuilder.Entity<Abilities>().Navigation(a => a.Strength).AutoInclude();
            modelBuilder.Entity<Abilities>().Navigation(a => a.Constitution).AutoInclude();
            modelBuilder.Entity<Abilities>().Navigation(a => a.Dexterity).AutoInclude();
            modelBuilder.Entity<Abilities>().Navigation(a => a.Wisdom).AutoInclude();
            modelBuilder.Entity<Abilities>().Navigation(a => a.Intelligence).AutoInclude();
            modelBuilder.Entity<Abilities>().Navigation(a => a.Charisma).AutoInclude();

            // auto include for getting all information through skills
            modelBuilder.Entity<Skills>().Navigation(s => s.Acrobatics).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.AnimalHandling).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Arcana).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Athletics).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Deception).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.History).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Insight).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Intimidation).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Investigation).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Medicine).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Nature).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Perception).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Performance).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Persuation).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Religion).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.SleightOfHand).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Stealth).AutoInclude();
            modelBuilder.Entity<Skills>().Navigation(s => s.Survival).AutoInclude();

            //// Seed info
            //Seeder.SeedCharacters(modelBuilder);
            //Seeder.SeedAbilities(modelBuilder);
            //Seeder.SeedStyle(modelBuilder);
            //Seeder.SeedSpeed(modelBuilder);
            //Seeder.SeedSkills(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console

        }
    }
}
