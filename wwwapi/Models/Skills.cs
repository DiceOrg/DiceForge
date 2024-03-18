using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace wwwapi.Models
{
    [Table("skills")]
    public class Skills
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("acrobatics_id"), ForeignKey("Skill"), JsonIgnore]
        public int AcrobaticsId { get; set; }
        public Skill Acrobatics { get; set; }
        [Column("animal_handling_id"), ForeignKey("Skill"), JsonIgnore]
        public int AnimalHandlingId { get; set; }
        [Column("animal_handling")]
        public Skill AnimalHandling { get; set; }
        [Column("arcana_id"), ForeignKey("Skill"), JsonIgnore]
        public int ArcanaId { get; set; }
        [Column("arcana")]
        public Skill Arcana { get; set; }
        [Column("athletics_id"), ForeignKey("Skill"), JsonIgnore]
        public int AthleticsId { get; set; }
        [Column("athletics")]
        public Skill Athletics { get; set; }
        [Column("deception_id"), ForeignKey("Skill"), JsonIgnore]
        public int DeceptionId { get; set; }
        [Column("deception")]
        public Skill Deception { get; set; }
        [Column("history_id"), ForeignKey("Skill"), JsonIgnore]
        public int HistoryId {  get; set; }
        [Column("history")]
        public Skill History { get; set; }
        [Column("insight_id"), ForeignKey("Skill"), JsonIgnore]
        public int InsightId { get; set; }
        [Column("insight")]
        public Skill Insight { get; set; }
        [Column("intimidation_id"), ForeignKey("Skill"), JsonIgnore]
        public int IntimidationId { get; set; }
        [Column("intimidation")]
        public Skill Intimidation { get; set; }
        [Column("investigation_id"), ForeignKey("Skill"), JsonIgnore]
        public int InvestigationId { get; set; }
        [Column("investigation")]
        public Skill Investigation { get; set; }
        [Column("medicine_id"), ForeignKey("Skill"), JsonIgnore]
        public int MedicineId { get; set; }
        [Column("medicine")]
        public Skill Medicine { get; set; }
        [Column("nature_id"), ForeignKey("Skill"), JsonIgnore]
        public int NatureId { get; set; }
        [Column("nature")]
        public Skill Nature { get; set; }
        [Column("perception_id"), ForeignKey("Skill"), JsonIgnore]
        public int PerceptionId { get; set; }
        [Column("perception")]
        public Skill Perception { get; set; }
        [Column("performance_id"), ForeignKey("Skill"), JsonIgnore]
        public int PerformanceId { get; set; }
        public Skill Performance { get; set; }
        [Column("persuation_id"), ForeignKey("Skill"), JsonIgnore]
        public int PersuationId { get; set; }
        [Column("persuation")]
        public Skill Persuation { get; set; }
        [Column("religion_id"), ForeignKey("Skill"), JsonIgnore]
        public int ReligionId { get; set; }
        [Column("religion")]
        public Skill Religion { get; set; }
        [Column("sleight_of_hand_id"), ForeignKey("Skill"), JsonIgnore]
        public int SleightOfHandId { get; set; }
        [Column("sleight_of_hand")]
        public Skill SleightOfHand { get; set; }
        [Column("stealth_id"), ForeignKey("Skill"), JsonIgnore]
        public int StealthId { get; set; }
        [Column("stealth")]
        public Skill Stealth { get; set; }
        [Column("survival_id"), ForeignKey("Skill"), JsonIgnore]
        public int SurvivalId { get; set; }
        [Column("survival")]
        public Skill Survival { get; set; }
        [Column("character_id"), ForeignKey("Character"), JsonIgnore]
        public int CharacterId { get; set; }
    }
}
