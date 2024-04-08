using System.Reflection;
using wwwapi.Models;
using wwwapi.Repository;

namespace wwwapi.Helpers
{
    public static class CharacterHelper
    {
        public static async Task<Character> toCharacter(string name, 
            IRepository<Ability> abilityRepository,
            IRepository<Character> characterRepository, IRepository<Skill> skillRepository,
            IRepository<Style> styleRepository, IRepository<Health> healthRepository,
            string userId)
        {

            Character character = await characterRepository.Create(new Character()
            {
                Level = 1,
                UserId = userId
            });


            await CharacterHelper.toHitPoints(healthRepository, character.Id);
            await CharacterHelper.toAbilities(abilityRepository, character.Id);
            await CharacterHelper.toSkills(skillRepository, character.Id);
            await CharacterHelper.toStyle(styleRepository, character.Id, name);

            return character;
        }

        public static async Task<Health> toHitPoints(IRepository<Health> repository, int id)
        {
            return await repository.Create(new Health() { CharacterId = id });
        }

        public static async Task<List<Ability>> toAbilities(IRepository<Ability> repository, int id)
        {
            List<string> propertyNames = new List<string>
            {
                "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma"
            };

            List<Ability> abilities = new List<Ability>();

            foreach (string propertyName in propertyNames)
            {
                Ability ability = new Ability()
                {
                    Name = propertyName, 
                    CharacterId = id,
                };
                await repository.Create(ability);
                abilities.Add(ability);
            }

            return abilities;
        }

/*        public static async Task<Speed> toSpeed(IRepository<Speed> repository, int id)
        {
            return await repository.Create(new Speed() { CharacterId = id });
        }*/

        public static Dictionary<string, AbilitiesEnum> SkillToAbility = new Dictionary<string, AbilitiesEnum>
        {
            { "Acrobatics", AbilitiesEnum.Dexterity }, 
            { "AnimalHandling", AbilitiesEnum.Wisdom }, 
            { "Arcana", AbilitiesEnum.Intelligence }, 
            { "Athletics", AbilitiesEnum.Strength }, 
            { "Deception", AbilitiesEnum.Charisma }, 
            { "History", AbilitiesEnum.Intelligence }, 
            { "Insight", AbilitiesEnum.Wisdom },
            { "Intimidation", AbilitiesEnum.Charisma }, 
            { "Investigation", AbilitiesEnum.Intelligence }, 
            { "Medicine", AbilitiesEnum.Wisdom}, 
            { "Nature", AbilitiesEnum.Intelligence }, 
            { "Perception", AbilitiesEnum.Wisdom},
            { "Performance", AbilitiesEnum.Charisma }, 
            { "Persuation", AbilitiesEnum.Charisma }, 
            { "Religion", AbilitiesEnum.Intelligence }, 
            { "SleightOfHand", AbilitiesEnum.Dexterity }, 
            { "Stealth", AbilitiesEnum.Dexterity }, 
            { "Survival", AbilitiesEnum.Wisdom }
        };

        public static async Task<List<Skill>> toSkills(IRepository<Skill> repository, int id)
        {
            List<Skill> skills = new List<Skill>();

            foreach (string propertyName in SkillToAbility.Keys)
            {
                Skill skill = new Skill()
                {
                    Name = propertyName,
                    Attribute = SkillToAbility[propertyName], 
                    CharacterId = id
                };
                await repository.Create(skill);
                skills.Add(skill);
            }

            return skills;
        }

        public static async Task<Style> toStyle(IRepository<Style> repository, int id, string name)
        {
            return await repository.Create(new Style() { CharacterId = id, Name = name });;
        }

/*        public static async Task<bool> deleteCharacter(Character character, 
            IRepository<Ability> abilityRepository,
            IRepository<Character> characterRepository, IRepository<Skill> skillRepository,
            IRepository<Style> styleRepository, IRepository<HitPoints> healthRepository){

            Abilities abilities = character.Abilities;
            Skills skills = character.Skills;

            
            foreach (string propertyName in SkillToAbility.Keys) {
                PropertyInfo property = skills.GetType().GetProperty(propertyName);

                await skillRepository.Delete((Skill) property.GetValue(skills));
            }

            List<string> propertyNames = new List<string>
            {
                "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma"
            };

            foreach (string propertyName in propertyNames)
            {
                PropertyInfo property = abilities.GetType().GetProperty(propertyName);

                await abilityRepository.Delete((Ability) property.GetValue(abilities));
            }


            // This is solved by cascade from auto-include
*//*            await healthRepository.Delete(character.HitPoints);
            await speedRepository.Delete(character.Speed);
            await styleRepository.Delete(character.Style);
            await abiltiesRepository.Delete(abilities);
            await skillsRepository.Delete(skills);*//*

            await characterRepository.Delete(character);


            return true;
        }
*/    }

}