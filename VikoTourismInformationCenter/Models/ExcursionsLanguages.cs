using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class ExcursionsLanguages
    {
        public int Id { get; set; }
        [Required]
        public Excursions? Excursion { get; set; }
        [Required]
        public Languages? Language { get; set; }
    }
}
