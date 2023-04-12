using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class ExcursionsPlaces
    {
        public int Id { get; set; }
        [Required] 
        public Places? Place { get; set; }
        [Required]
        public Excursions? Excursion { get; set; }
    }
}
