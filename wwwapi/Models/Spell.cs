using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace wwwapi.Models
{
    [Table("spells")]
    public class Spell
    {
        [Column("id"), JsonIgnore]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("index")]
        public string Index { get; set; }
        [Column("character_id"), ForeignKey("Character"), JsonIgnore]
        public int CharacterId { get; set; }
    }
}
