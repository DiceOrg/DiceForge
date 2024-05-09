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

            characterGroup.MapPut("/{id}", UpdateCharacter);

            characterGroup.MapPost("{id}/Spells", CreateSpell);

            characterGroup.MapDelete("/{id}", DeleteCharacter);


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
            IRepository<Spell> spellRepository,
            ClaimsPrincipal user
            )
        {
            Character character = await repository.Get(id);
            if (character == null)
                return TypedResults.NotFound("No characters found");
            if (user.UserId() != character.UserId)
                return TypedResults.Unauthorized();

            character.Abilities = abilityRepository.GetByCondition(a => a.CharacterId == id).ToList();
            character.Health = healthRepository.GetByCondition(h => h.CharacterId == id).First();
            character.Skills = skillRepository.GetByCondition(s => s.CharacterId == id).ToList();
            character.Style = styleRepository.GetByCondition(st => st.CharacterId == id).First();
            character.Spells = spellRepository.GetByCondition(sp => sp.CharacterId == id).ToList();

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
        public static async Task<IResult> UpdateCharacter(IRepository<Character> repository,
            IRepository<Ability> abilityRepository,
            IRepository<Character> characterRepository, IRepository<Skill> skillRepository,
            IRepository<Style> styleRepository, IRepository<Health> healthRepository,
            int id,
            CharacterDto characterDto, ClaimsPrincipal user)
        {
            Character character = await repository.Get(id);
            if (character == null)
                return TypedResults.NotFound();

            if (user.UserId() != character.UserId)
                return TypedResults.Unauthorized();

            character.Abilities = abilityRepository.GetByCondition(a => a.CharacterId == id).ToList();
            character.Health = healthRepository.GetByCondition(h => h.CharacterId == id).FirstOrDefault();
            character.Skills = skillRepository.GetByCondition(s => s.CharacterId == id).ToList();
            character.Style = styleRepository.GetByCondition(st => st.CharacterId == id).FirstOrDefault();



            character.Update(characterDto);

            Character result = await repository.Update(character);

            return TypedResults.Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public static async Task<IResult> CreateSpell(IRepository<Spell> repository, IRepository<Character> characterRepository, 
            int id, Spell spell, ClaimsPrincipal user)
        {
            Character character = await characterRepository.Get(id);
            if (character == null || id != character.Id)
                return TypedResults.BadRequest();
            if (user.UserId() != character.UserId)
                return TypedResults.Unauthorized();
            List<Spell> duplicates = repository.GetByCondition(sp => sp.CharacterId == character.Id).ToList();
            if (duplicates.Count(sp => sp.Index == spell.Index) > 0) 
                return TypedResults.BadRequest();

            spell.CharacterId = character.Id;
            Spell result = await repository.Create(spell);

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
    }
}

