using System.ComponentModel.DataAnnotations.Schema;

namespace wwwapi.Models
{
    [Table("characters")]
    public class Character
    {
        [Column("id")]
        public int Id { get; set; }
        public String Name { get; set; }
        public Style Style { get; set; }
        public Abilities Abilities { get; set; }
        public Skills Skills { get; set; }
        public Speed Speed { get; set; }
    }
}
