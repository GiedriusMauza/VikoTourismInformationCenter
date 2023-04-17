using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VikoTourismInformationCenter.Models
{
    public class Places
    {
        [ForeignKey("Addresses")]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [NotMapped]
        public int? AddressIdValue { get; set; }

        public virtual Addresses? Addresses { get; set; }
    }
}
