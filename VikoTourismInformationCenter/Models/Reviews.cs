using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace VikoTourismInformationCenter.Models
{
    public class Reviews
    {
        [Required]
        public int Id { get; set; }
        [DefaultValue(true)]
        public Places? Place { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Comment { get; set; }
        [Required]
        public DateTime Date{ get; set; }
        [NotMapped]
        public string? PlaceName { get; set; }

    }
}
