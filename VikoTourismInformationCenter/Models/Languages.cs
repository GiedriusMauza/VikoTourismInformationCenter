using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class Languages
    {
        public int Id { get; set; }
        [Required]
        public string? Language { get; set; }
    }
}
