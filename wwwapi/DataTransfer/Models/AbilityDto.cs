using System.ComponentModel.DataAnnotations.Schema;

namespace wwwapi.DataTransfer.Models
{
    public class AbilityDto
    {
        public string Name { get; set; }
        public int Value { get; set; } = 8;
        public bool Prof { get; set; } = false;
    }
}
