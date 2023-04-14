using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class Addresses
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string? Region { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string? City { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(10)]
        public string? HouseNo { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int PostalCode { get; set; }
    }
}
