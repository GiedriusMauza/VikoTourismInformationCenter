﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VikoTourismInformationCenter.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        public DateTime DateCreated { get; set; }

        [NotMapped] // just for display, no pushing to DB
        public string? RoleId { get; set; }

        [NotMapped]
        public string? Role { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? RoleList { get; set; }

        [NotMapped]
        public string? ResidentGroupName { get; set; }

        [NotMapped]
        public string? ResidentGroupSelected { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? ResidentGroupList { get; set; }

        [NotMapped]
        public ICollection<PlacesContacts>? PlacesContacts { get; set; }
    }
}