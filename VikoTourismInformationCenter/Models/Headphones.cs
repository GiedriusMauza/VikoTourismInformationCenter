using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class Headphones
    {
        public int Id { get; set; }
        public Excursions? Excursion { get; set; }
        [Required]
        public string? Model { get; set; }

    }
}
