using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using wwwapi.Helpers;
using wwwapi.Models;

namespace wwwapi.Data
{
    /*public static class Seeder
    {

        public static void SeedCharacters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(new List<Character>{
                new Character()
                {
                    Id = 1
                }, 
                new Character()
                {
                    Id = 2
                }
            });
        }

        public static void SeedAbilities(ModelBuilder modelBuilder)
        {
            int numAbilities = 1;


            List<Abilities> abilities = new List<Abilities>();
            for ( int i = 1; i <= 2; i++ )
            {
                abilities.Add(new Abilities()
                {
                    Id = i,
                    StrengthId = numAbilities++,
                    DexterityId = numAbilities++,
                    ConstitutionId = numAbilities++,
                    IntelligenceId = numAbilities++,
                    WisdomId = numAbilities++,
                    CharismaId = numAbilities++,
                    CharacterId = i,
                });
            }

            List<Ability> abilityList = new List<Ability>();
            for (int i = 1; i < numAbilities; i++)
            {
                abilityList.Add(new Ability()
                {
                    Id = i,
                    Prof = i % 2 == 0,
                    Value = i % 20,
                });
            }

            modelBuilder.Entity<Ability>().HasData(abilityList);

            modelBuilder.Entity<Abilities>().HasData(abilities);
        }

        public static void SeedStyle(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Style>().HasData(new List<Style>
            {
                new Style()
                {
                    Id = 1,
                    Name = "Name",
                    Description = "Description",
                    Age = 21, 
                    Height = "2'11", 
                    Width = "2'6",
                    Eyes = "Blue", 
                    Hair = "Not blue", 
                    Skin = "Blue", 
                    Race = "No", 
                    Class_ = "", 
                    Alignment = "", 
                    Background = "",

                    CharacterId = 1
                },
                new Style()
                {
                    Id = 2,
                    Name = "Other Name",
                    Description = "Other Description",
                    Age = 22,
                    Height = "4'11",
                    Width = "1'6",
                    Eyes = "Other Blue",
                    Hair = "Other Not blue",
                    Skin = "Other Blue",
                    Race = "Other No",
                    Class_ = "",
                    Alignment = "",
                    Background = "",

                    CharacterId = 2
                }
            });
        }

        public static void SeedSkills(ModelBuilder modelBuilder)
        {

            List<Skills> skills = new List<Skills>();

            int numSkills = 1;

            for (int i = 1; i <= 2; i++)
            {
                skills.Add(new Skills()
                {
                    Id = i,

                    AcrobaticsId = numSkills++,
                    AnimalHandlingId = numSkills++,
                    ArcanaId = numSkills++,
                    AthleticsId = numSkills++,
                    DeceptionId = numSkills++,
                    HistoryId = numSkills++,
                    InsightId = numSkills++,
                    IntimidationId = numSkills++,
                    InvestigationId = numSkills++,
                    MedicineId = numSkills++,
                    NatureId = numSkills++,
                    PerceptionId = numSkills++,
                    PerformanceId = numSkills++,
                    PersuationId = numSkills++,
                    ReligionId = numSkills++,
                    SleightOfHandId = numSkills++,
                    StealthId = numSkills++,
                    SurvivalId = numSkills++,

                    CharacterId = i,
                });
            }

            List<Skill> skillList = new List<Skill>();

            List<AbilitiesEnum> abilities = CharacterHelper.SkillToAbility.Values.ToList();

            for (int i = 1; i < numSkills; i++)
            {
                skillList.Add(new Skill()
                {
                    Id = i,
                    Prof = i % 3 == 0,
                    Exp = i % 5 == 0, 
                    Attribute = abilities[i % abilities.Count]
                });
            }

            modelBuilder.Entity<Skill>().HasData(skillList);

            modelBuilder.Entity<Skills>().HasData(skills);
        }

        public static void SeedSpeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speed>().HasData(new List<Speed> { 
                new Speed()
                {
                    Id = 1, 
                    Value = 30, 
                    CharacterId = 1
                }, 
                new Speed()
                {
                    Id = 2, 
                    Value = 35, 
                    CharacterId = 2
                }
            });
        }
    }*/
}
