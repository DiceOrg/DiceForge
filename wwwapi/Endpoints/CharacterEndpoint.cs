using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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


    }
}
