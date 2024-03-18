using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace wwwapi.Models
{
    [Table("abilities")]
    public class Abilities
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("strength_id"), ForeignKey("Ability"), JsonIgnore]
        public int StrengthId { get; set; }
        [Column("strength")]
        public Ability Strength { get; set; }
        [Column("dexterity_id"), ForeignKey("Ability"), JsonIgnore]
        public int DexterityId { get; set; }
        [Column("dexterity")]
        public Ability Dexterity { get; set; }
        [Column("constitution_id"), ForeignKey("Ability"), JsonIgnore]
        public int ConstitutionId { get; set; }
        [Column("constitution")]
        public Ability Constitution { get; set; }
        [Column("intelligence_id"), ForeignKey("Ability"), JsonIgnore]
        public int IntelligenceId { get; set; }
        [Column("intelligence")]
        public Ability Intelligence { get; set; }
        [Column("wisdom_id"), ForeignKey("Ability"), JsonIgnore]
        public int WisdomId { get; set; }
        [Column("wisdom")]
        public Ability Wisdom { get; set; }
        [Column("charisma_id"), ForeignKey("Ability"), JsonIgnore]
        public int CharismaId { get; set; }
        [Column("charisma")]
        public Ability Charisma { get; set; }
        [Column("character_id"), ForeignKey("Character"), JsonIgnore]
        public int CharacterId { get; set; }
    }
}
