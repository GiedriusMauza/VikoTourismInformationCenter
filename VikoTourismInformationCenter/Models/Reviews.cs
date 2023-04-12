using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class Reviews
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Places? Place { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Comment { get; set; }
        [Required]
        public DateTime Date{ get; set; } = DateTime.Now;

    }
}
