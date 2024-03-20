using System.ComponentModel.DataAnnotations.Schema;
using wwwapi.DataTransfer.Models;

namespace wwwapi.Models
{
    [Table("ability")]
    public class Ability
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("value")]
        public int Value { get; set; } = 8;
        [Column("prof")]
        public bool Prof { get; set; } = false;
        public void Update(AbilityDto abilityDto)
        {
            Value = abilityDto.Value;
            Prof = abilityDto.Prof;
        }
    }
}
