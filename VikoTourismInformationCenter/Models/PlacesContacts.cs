using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VikoTourismInformationCenter.Models
{
    public class PlacesContacts
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public ApplicationUser? ApplicationUser { get; set; }
        [Required]
        public Places? Places { get; set; }

    }
}
