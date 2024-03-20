using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using wwwapi.DataTransfer.Models;

namespace wwwapi.Models
{
    [Table("speed")]
    public class Speed
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("value")]
        public int Value { get; set; } = 0;
        [Column("character_id"), ForeignKey("Character"), JsonIgnore]
        public int CharacterId { get; set; }

        public void Update(SpeedDto speedDto) { Value = speedDto.Value; }
    }
}
