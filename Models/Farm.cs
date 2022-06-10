using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models
{
    public class Farm
    {
        [Key]
        public int FarmId { get; set; }
        public int Hectare { get; set; }
        public string TenurialStatus { get; set; }
        public string FarmAddress { get; set; }
        public Farmer? Farmer { get; set; }
        public int FarmerId { get; set; }
    }
}
