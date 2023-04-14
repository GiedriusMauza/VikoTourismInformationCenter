using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        [Display(Name = "Assigned Manager")]
        public string? UserEmailAddress { get; set; }

        [NotMapped]
        [Display(Name = "Languages Available")]
        public string? LanguagesAvailable { get; set; }

        [NotMapped]
        public IEnumerable<Languages>? LanguagesList { get; set; }

    }
}
