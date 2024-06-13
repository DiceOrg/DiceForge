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
        [Column("name")]
        public string Name { get; set; }
        [Column("attribute")]
        public AbilitiesEnum Attribute { get; set; }
        [Column("prof")]
        public bool Prof { get; set; } = false;
        [Column("exp")]

        public bool Exp { get; set; } = false;
        [Column("character_id"), ForeignKey("Character")]
        public int CharacterId { get; set; }

        public void Update(SkillDto skillDto) {
            if (skillDto.Name != Name)
                throw new ArgumentException("Element does not match element to change");
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
