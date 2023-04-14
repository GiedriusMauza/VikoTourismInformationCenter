using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VikoTourismInformationCenter.Models
{
    public class WorkHours
    {
        [Required]
        public int Id { get; set; }
        [DefaultValue(true)]
        public Places? Place{ get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public string? WeekDays { get; set; }
        [NotMapped]
        public string? PlaceName { get; set; }
    }
}
