#region Addiotnal Namespace
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrainWatchSystem.BLL;
using TrainWatchSystem.DAL;
#endregion


namespace TrainWatchSystem
{
    public static class StartupExtension
    {
        public static void AddBackendDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<TrainWatchContext>(options); 

            services.AddTransient<TrainWatchServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<TrainWatchContext>();
                return new TrainWatchServices(context);
            });
            services.AddTransient<RollingStockServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<TrainWatchContext>();
                return new RollingStockServices(context);
            });
            services.AddTransient<RailCarTypeServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<TrainWatchContext>();
                return new RailCarTypeServices(context);
            });
        }
    }
}
