using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using wwwapi.Models;

namespace wwwapi.DataTransfer.Models
{
    public class CharacterDto
    {
        public StyleDto Style { get; set; }
        public List<AbilityDto> Abilities { get; set; }
        public List<SkillDto> Skills { get; set; }
        public int Speed { get; set; }
        public HealthDto Health { get; set; }
        public List<Spell> Spells { get; set; }
    }
}
