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
        [Column("level")]
        public int Level { get; set; }
        public Style Style { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Skill> Skills { get; set; }
        public int Speed { get; set; } = 0;
        public Health Health { get; set; }
        public List<Spell> Spells { get; set; }
        [Column("user_id"), ForeignKey("user"), JsonIgnore]
        public string UserId { get; set; }
    }
}
