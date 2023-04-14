using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VikoTourismInformationCenter.Models
{
    public class Places
    {
        [Required]
        public int Id { get; set; }
        [DefaultValue(true)]
        public Addresses? Address { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [NotMapped]
        public int? AddressIdValue { get; set; }
    }
}
