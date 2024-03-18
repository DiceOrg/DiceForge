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

    }
}
