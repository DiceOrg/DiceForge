using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Xml.Linq;
using wwwapi.DataTransfer.Models;
using wwwapi.Helpers;
using wwwapi.Models;
using wwwapi.Repository;

namespace wwwapi.Endpoints
{
    public static class CharacterEndpoint
    {

        public static void ConfigureCharacterEndpoint(this WebApplication app)
        {
            var characterGroup = app.MapGroup("character");

            characterGroup.MapGet("", GetCharacters);
            characterGroup.MapGet("/{id}", GetCharacter);

            characterGroup.MapPost("/", CreateCharacter);

            characterGroup.MapPut("/Ability/{id}", UpdateAbility);
            // characterGroup.MapPut("/{id}", UpdateCharacter);
            characterGroup.MapPut("/Skill/{id}", UpdateSkill);
            // characterGroup.MapPut("/Speed/{id}", UpdateSpeed);
            characterGroup.MapPut("/Style/{id}", UpdateStyle);

            characterGroup.MapDelete("/{id}", DeleteCharacter);
            characterGroup.MapPut("/Hitpoints/{id}", UpdateHitPoints);


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCharacters(IRepository<Character> repository, ClaimsPrincipal user)
        {
            string id = user.UserId();
            IQueryable<Character> characters = repository.GetByCondition(u => u.UserId == id);
            if ( characters == null) 
                return TypedResults.NotFound("No characters found"); 

            return TypedResults.Ok(characters);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public static async Task<IResult> GetCharacter(IRepository<Character> repository, int id,
            IRepository<Ability> abilityRepository, IRepository<Health> healthRepository,
            IRepository<Skill> skillRepository, IRepository<Style> styleRepository,
            ClaimsPrincipal user
            )
        {
            Character character = await repository.Get(id);
            if (character == null)
                return TypedResults.NotFound("No characters found");
            if (user.UserId() != character.UserId)
                return TypedResults.Unauthorized();
            character.Abilities = abilityRepository.GetByCondition(a => a.CharacterId == id).ToList();
            character.Health = healthRepository.GetByCondition(h => h.CharacterId == id).FirstOrDefault();
            character.Skills = skillRepository.GetByCondition(s => s.CharacterId == id).ToList();
            character.Style = styleRepository.GetByCondition(st => st.CharacterId == id).FirstOrDefault();

            return TypedResults.Ok(character);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateCharacter(IRepository<Character> repository, String name, 
            IRepository<Ability> abilityRepository,
            IRepository<Character> characterRepository, IRepository<Skill> skillRepository,
            IRepository<Style> styleRepository, IRepository<Health> heathRepository, 
            ClaimsPrincipal user)
        {
            if (name == null)
                return TypedResults.BadRequest("Name needs to have a value");

            string id = user.UserId();
            Character character = await CharacterHelper.toCharacter(name, abilityRepository,
            characterRepository, skillRepository,
            styleRepository, heathRepository, id);
            

            return TypedResults.Ok(character);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateAbility(IRepository<Ability> repository, int id, AbilityDto abilityDto)
        {
            Ability ability = await repository.Get(id);
            if (ability == null)
                return TypedResults.NotFound();

            ability.Update(abilityDto);

            Ability result = await repository.Update(ability);

            return TypedResults.Ok(result);
        }

/*        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateCharacter(IRepository<Character> repository, int id, 
            CharacterDto characterDto, ClaimsPrincipal user)
        {
            Character character = await repository.Get(id);
            if (character == null)
                return TypedResults.NotFound();

            if (user.UserId() != character.UserId)
                return TypedResults.Unauthorized();



            character.Update(characterDto);

            Character result = await repository.Update(character);

            return TypedResults.Ok(result);
        }*/

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateSkill(IRepository<Skill> repository, int id, SkillDto skillDto)
        {
            Skill skill = await repository.Get(id);
            if (skill == null ) return 
                TypedResults.NotFound();

            skill.Update(skillDto);

            Skill result = await repository.Update(skill);

            return TypedResults.Ok(result);
        }

/*        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateSpeed(IRepository<Speed> repository, int id, SpeedDto speedDto)
        {
            Speed speed = await repository.Get(id);
            if (speed == null)
                return TypedResults.NotFound();

            speed.Update(speedDto);

            Speed result = await repository.Update(speed);

            return TypedResults.Ok(result);
        }*/

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateStyle(IRepository<Style> repository, int id, StyleDto styleDto)
        {
            Style style = await repository.Get(id);
            if (style == null)
                return TypedResults.NotFound();

            style.Update(styleDto);

            Style result = await repository.Update(style);

            return TypedResults.Ok(result);
        }

        public static async Task<IResult> DeleteCharacter(IRepository<Character> repository, 
            IRepository<Ability> abilityRepository, 
            IRepository<Character> characterRepository, IRepository<Skill> skillRepository, 
            IRepository<Style> styleRepository, IRepository<Health> healthRepository,
            int id, ClaimsPrincipal user) {

            Character character = await repository.Get(id);

            if ( character == null )
                return TypedResults.NotFound("Character not found");

            if (user.UserId() != character.UserId)
                return TypedResults.Unauthorized();

            character.Abilities = abilityRepository.GetByCondition(a => a.CharacterId == id).ToList();
            character.Health = healthRepository.GetByCondition(h => h.CharacterId == id).FirstOrDefault();
            character.Skills = skillRepository.GetByCondition(s => s.CharacterId == id).ToList();
            character.Style = styleRepository.GetByCondition(st => st.CharacterId == id).FirstOrDefault();

            await repository.Delete(character);

            return TypedResults.Ok(character);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateHitPoints(IRepository<Health> repository, int id, HealthDto hitPointDto)
        {
            Health hp = await repository.Get(id);
            if (hp == null)
                return TypedResults.NotFound();

            hp.Update(hitPointDto);

            Health result = await repository.Update(hp);

            return TypedResults.Ok(result);
        }
    }
}

