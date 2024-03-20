using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using wwwapi.DataTransfer.Models;

namespace wwwapi.Models
{
    [Table("skill")]
    public class Skill
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("attribute")]
        public AbilitiesEnum Attribute { get; set; }
        [Column("prof")]
        public bool Prof { get; set; } = false;
        [Column("exp")]

        public bool Exp { get; set; } = false;

        public void Update(SkillDto skillDto) { 
            Attribute = skillDto.Attribute;
            Prof = skillDto.Prof;
            Exp = skillDto.Exp;
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AbilitiesEnum
    {
        Strength, 
        Dexterity, 
        Constitution, 
        Intelligence, 
        Wisdom, 
        Charisma
    }
}
