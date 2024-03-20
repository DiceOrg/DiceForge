using System.ComponentModel.DataAnnotations.Schema;
using wwwapi.Models;

namespace wwwapi.DataTransfer.Models
{
    public class StyleDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int? Age { get; set; } = null;
        public string Height { get; set; } = "";
        public string Width { get; set; } = "";
        public string Eyes { get; set; } = "";
        public string Hair { get; set; } = "";
        public string Skin { get; set; } = "";
        public string Race { get; set; } = "";
        public Class_? Class_ { get; set; } = null;
        public Alignment? Alignment { get; set; } = null;
        public Background? Background { get; set; } = null;
    }
}
