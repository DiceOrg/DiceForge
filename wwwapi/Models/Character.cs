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
        public string Name { get; set; }
        public int Level { get; set; }
        public Style Style { get; set; }
        public Abilities Abilities { get; set; }
        public Skills Skills { get; set; }
        public Speed Speed { get; set; }
        public HitPoints HitPoints { get; set; }
        [Column("user_id"), ForeignKey("user"), JsonIgnore]
        public string UserId { get; set; }

        public void Update(CharacterDto characterDto) { Name = characterDto.Name; }
    }
}
