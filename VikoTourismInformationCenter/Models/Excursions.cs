using System.ComponentModel.DataAnnotations;
using VikoServiceManager.Models;

namespace VikoTourismInformationCenter.Models
{
    public class Excursions
    {
        public int Id { get; set; }
        [Required]
        public ApplicationUser? ApplicationUser { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public float Price { get; set; }

    }
}
