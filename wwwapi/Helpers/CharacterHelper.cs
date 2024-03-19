﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;
using wwwapi.Models;
using wwwapi.Repository;

namespace wwwapi.Helpers
{
    public static class CharacterHelper
    {
        public static async Task<Character> toCharacter(string name, 
            IRepository<Abilities> abiltiesRepository, IRepository<Ability> abilityRepository, 
            IRepository<Character> characterRepository, IRepository<Skill> skillRepository,
            IRepository<Skills> skillsRepository, IRepository<Speed> speedRepository, 
            IRepository<Style> styleRepository)
        {

            Character character = await characterRepository.Create(new Character()
            {
                Name = name,
            });

            await CharacterHelper.toAbilities(abiltiesRepository, abilityRepository, character.Id);
            await CharacterHelper.toSkills(skillsRepository, skillRepository, character.Id);
            await CharacterHelper.toSpeed(speedRepository, character.Id);
            await CharacterHelper.toStyle(styleRepository, character.Id);

            return character;
        }

        public static async Task<Ability> toAbility(IRepository<Ability> repository)
        {
            return await repository.Create(new Ability() { });
        }

        public static async Task<Abilities> toAbilities(IRepository<Abilities> repository, IRepository<Ability> abilityRepository, int id)
        {
            List<string> propertyNames = new List<string>
            {
                "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma"
            };

            Abilities abilities = new Abilities() { CharacterId = id };

            foreach (string propertyName in propertyNames)
            {
                PropertyInfo property = typeof(Abilities).GetProperty(propertyName + "Id");
                Ability ability = await CharacterHelper.toAbility(abilityRepository);
                property.SetValue(abilities, ability.Id);
            }

            return await repository.Create(abilities);
        }

        public static async Task<Speed> toSpeed(IRepository<Speed> repository, int id)
        {
            return await repository.Create(new Speed() { CharacterId = id });
        }

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

        public static async Task<Skills> toSkills(IRepository<Skills> repository, IRepository<Skill> skillRepository, int id)
        {
            Skills skills = new Skills() { CharacterId = id };

            foreach (string propertyName in SkillToAbility.Keys)
            {
                PropertyInfo property = typeof(Skills).GetProperty(propertyName + "Id");
                Skill skill = await CharacterHelper.toSkill(skillRepository, SkillToAbility.GetValueOrDefault(propertyName));
                property.SetValue(skills, skill.Id);
            }

            return await repository.Create(skills);
        }
        public static async Task<Skill> toSkill(IRepository<Skill> repository, AbilitiesEnum ability)
        {
            return await repository.Create(new Skill() { Attribute = ability, });
        }

        public static async Task<Style> toStyle(IRepository<Style> repository, int id)
        {
            return await repository.Create(new Style() { CharacterId = id });;
        } 
    }
}