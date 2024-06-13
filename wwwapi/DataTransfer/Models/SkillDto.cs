using System.ComponentModel.DataAnnotations.Schema;
using wwwapi.Models;

namespace wwwapi.DataTransfer.Models
{
    public class SkillDto
    {
        public string Name { get; set; }
        public bool Prof { get; set; } = false;
        public bool Exp { get; set; } = false;
    }
}
