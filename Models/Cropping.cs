using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models
{
    public class Cropping
    {
        [Key]
        public int CroppingId { get; set; }
        public string Crop { get; set; }
        public List<Farm>? Farms { get; set; }
    }
}
