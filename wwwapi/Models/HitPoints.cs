using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using wwwapi.DataTransfer.Models;

namespace wwwapi.Models
{
    [Table("HitPoints")]
    public class HitPoints
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
        public int characterId { get; set; }

        public void Update(HitPointDto hitPointDto)
        {
            Current = hitPointDto.Current;
            Max = hitPointDto.Max;
            Temp = hitPointDto.Temp;
        }
    }
}
