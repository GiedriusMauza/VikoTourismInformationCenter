using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VikoServiceManager.Models;
using VikoTourismInformationCenter.Models;

namespace VikoTourismInformationCenter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<PlacesCategories> PlacesCategories { get; set; }
        public DbSet<Places> Places { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Excursions> Excursions { get; set; }
        public DbSet<ExcursionsLanguages> ExcursionsLanguages { get; set; }
        public DbSet<ExcursionsPlaces> ExcursionsPlaces { get; set; }
        public DbSet<Headphones> Headphones { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<PlacesContacts> PlacesContacts { get; set; }
        public DbSet<WorkHours> WorkHours { get; set; }

    }
}