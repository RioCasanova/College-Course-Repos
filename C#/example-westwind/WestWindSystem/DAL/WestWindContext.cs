#nullable disable
#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem.Entities;
#endregion


namespace WestWindSystem.DAL
{
    // This class and not the access from outside the class library project.
    // Any reference within the class library project to this class will be honored.
    // This is a level of security, one point of entry into our data, this is a rinse and repeat for other projects
    internal class WestWindContext : DbContext
    {
        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {

        }
        public DbSet<BuildVersion> buildVersions { get; set; }
        public DbSet<Region> regions { get; set;}
        public DbSet<Territory> territories { get; set; }
    }
}
