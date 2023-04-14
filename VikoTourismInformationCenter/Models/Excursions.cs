using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class Excursions
    {
        public int Id { get; set; }
        [DefaultValue(true)]
        public ApplicationUser? ApplicationUser { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public float Price { get; set; }

    }
}
