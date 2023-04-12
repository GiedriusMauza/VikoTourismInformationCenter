using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class WorkHours
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Places? Place{ get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public string? WeekDays { get; set; }

    }
}
