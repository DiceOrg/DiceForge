using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using wwwapi.DataTransfer.Models;

namespace wwwapi.Models
{
    [Table("health")]
    public class Health
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("current")]
        public int Current { get; set; } = 0;
        [Column("max")]
        public int Max { get; set; }
        [Column("temp")]
        public int Temp { get; set; }

        [Column("character_id"), ForeignKey("Character"), JsonIgnore]
        public int CharacterId { get; set; }

        public void Update(HealthDto healthDto)
        {
            Current = healthDto.Current;
            Max = healthDto.Max;
            Temp = healthDto.Temp;
        }
    }
}
