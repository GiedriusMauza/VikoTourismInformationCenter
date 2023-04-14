using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class Headphones
    {
        public int Id { get; set; }
        [DefaultValue(true)]
        public Excursions? Excursion { get; set; }
        [Required]
        public string? Model { get; set; }

    }
}
