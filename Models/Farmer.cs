using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models
{
    public class Farmer
    {
        [Key]
        public int FarmerId { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]

        public string? MiddleName { get; set; } = string.Empty;


        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Birthday")]
        public DateTime BirthDate { get; set; }

        public List<Farm>? Farms { get; set; }

    }
}
