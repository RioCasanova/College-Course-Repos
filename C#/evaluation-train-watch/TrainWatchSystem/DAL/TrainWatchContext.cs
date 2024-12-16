
#nullable disable
#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using TrainWatchSystem.Entities;
#endregion

namespace TrainWatchSystem.DAL
{
    internal class TrainWatchContext : DbContext
    {
        public TrainWatchContext(DbContextOptions<TrainWatchContext> options) : base(options)
        {

        }
        public DbSet<DbVersion> dbBuildVersions { get; set; }
        public DbSet<RailCarTypes> railCarTypes { get; set; }
        public DbSet<RollingStock> rollingStock { get; set; }
    }
}
