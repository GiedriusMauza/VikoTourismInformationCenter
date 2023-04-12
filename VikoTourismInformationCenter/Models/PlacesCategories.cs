using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class PlacesCategories
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Categories? Category { get; set; }
        [Required]
        public Places? Place { get; set; }

    }
}
