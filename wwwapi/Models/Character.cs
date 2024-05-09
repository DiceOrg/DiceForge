using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using wwwapi.DataTransfer.Models;

namespace wwwapi.Models
{
    [Table("characters")]
    public class Character
    {
        [Column("id")]
        public int Id { get; set; }
        public Style Style { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Skill> Skills { get; set; }
        public int Speed { get; set; }
        public Health Health { get; set; }
        public List<Spell> Spells { get; set; }
        [Column("user_id"), ForeignKey("user"), JsonIgnore]
        public string UserId { get; set; }

        public void Update(CharacterDto dto)
        {
            Style.Update(dto.Style);
            for ( int i = 0; i < Skills.Count; i++ )
            {
                Skills[i].Update(dto.Skills[i]);
                if ( i <  Abilities.Count )
                    Abilities[i].Update(dto.Abilities[i]);
            }
            Speed = dto.Speed;
            Health.Update(dto.Health);
        }
    }
}
