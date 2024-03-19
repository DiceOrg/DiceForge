using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
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
            characterGroup.MapGet("/styles/{characterId}", GetStyle);
            characterGroup.MapGet("/{id}", GetCharacter);
            characterGroup.MapPost("/", CreateCharacter);

            characterGroup.MapPut("/Ability/{id}", UpdateAbility);
            characterGroup.MapPut("/{id}", UpdateCharacter);
            characterGroup.MapPut("/Atribute/{id}", UpdateSkill);
            characterGroup.MapPut("/Speed/{id}", UpdateSpeed);
            characterGroup.MapPut("/Style/{id}", UpdateStyle);


        }

        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCharacters(IRepository<Character> repository)
        {
            IEnumerable<Character> characters = await repository.Get();
            if ( characters == null) 
                return TypedResults.NotFound("No characters found"); 

            return TypedResults.Ok(characters);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetStyle(IRepository<Style> repository, int id)
        {
            IQueryable<Style> style = repository.GetByCondition(x => x.CharacterId == id);
            if (style == null) return TypedResults.NotFound("Ability scores not found");
            return TypedResults.Ok(style);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCharacter(IRepository<Character> repository, int id)
        {
            Character character = await repository.Get(id);
            if (character == null)
                return TypedResults.NotFound("No characters found");

            return TypedResults.Ok(character);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateCharacter(IRepository<Character> repository, String name,
            IRepository<Abilities> abiltiesRepository, IRepository<Ability> abilityRepository,
            IRepository<Character> characterRepository, IRepository<Skill> skillRepository,
            IRepository<Skills> skillsRepository, IRepository<Speed> speedRepository,
            IRepository<Style> styleRepository)
        {
            Character character = await CharacterHelper.toCharacter(name, abiltiesRepository, abilityRepository,
            characterRepository, skillRepository, skillsRepository, speedRepository,
            styleRepository);

            return TypedResults.Ok(character);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateAbility(IRepository<Ability> repository, int id, Ability ability)
        {
            if (ability == null || ability.Id != id) return TypedResults.BadRequest("Given Id does not correspond with the Id of object. ");

            Ability result = await repository.Update(ability);

            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateCharacter(IRepository<Character> repository, int id, Character character)
        {
            if (character == null || character.Id != id) return TypedResults.BadRequest("Given Id does not correspond with the Id of object. ");

            Character result = await repository.Update(character);

            return TypedResults.Ok(character);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateSkill(IRepository<Skill> repository, int id, Skill skill)
        {
            if (skill == null || skill.Id != id) return TypedResults.BadRequest("Given Id does not correspond with the Id of object. ");

            Skill result = await repository.Update(skill);

            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateSpeed(IRepository<Speed> repository, int id, Speed speed)
        {
            if (speed == null || speed.Id != id) return TypedResults.BadRequest("Given Id does not correspond with the Id of object. ");

            Speed result = await repository.Update(speed);

            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateStyle(IRepository<Style> repository, int id, Style style)
        {
            if (style == null || style.Id != id) return TypedResults.BadRequest("Given Id does not correspond with the Id of object. ");

            Style result = await repository.Update(style);

            return TypedResults.Ok(result);
        }

    }
}
