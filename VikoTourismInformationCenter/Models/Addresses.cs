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
        public int HouseNo { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(5)]
        [StringLength(5, MinimumLength = 5,
        ErrorMessage = "Postal Code should be 5 characters long")]
        public int PostalCode { get; set; }
    }
}
