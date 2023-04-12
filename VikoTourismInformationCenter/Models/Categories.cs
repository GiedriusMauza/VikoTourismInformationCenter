using System.ComponentModel.DataAnnotations;

namespace VikoTourismInformationCenter.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
