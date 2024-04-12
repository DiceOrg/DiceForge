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
        public string Class_ { get; set; } = "";
        public int? Level { get; set; } = null;
        public string Alignment { get; set; } = "";
        public string Background { get; set; } = "";
    }
}
