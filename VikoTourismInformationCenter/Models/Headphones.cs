using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VikoTourismInformationCenter.Models
{
    public class Headphones
    {
        public int Id { get; set; }
        [DefaultValue(true)]
        public Excursions? Excursion { get; set; }
        [Required]
        public string? Model { get; set; }

        [NotMapped]
        [Display(Name = "Assigned for Excursion")]
        public string? ExcursionName { get; set; }

    }
}
