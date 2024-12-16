#region Addiotnal Namespace
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.BLL;
using WestWindSystem.DAL;
#endregion


namespace WestWindSystem
{
    public static class BackendExtensions
    {
        public static void WWBackendDependencies(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            // Within this method we will register all the services that will be used by the system, which is our context setup and will be provided by 
            // the system.
            services.AddDbContext<WestWindContext>(options); // We use this options for our constructor for our WestWindContext

            // add any bsuiness logic layer class to the service collection so our
            // web app has accesss to the methods (services) within the BLL class

            // The argument for the AddTransient is called a factory, you are adding a localize method
            // We want to get theDbContext class that has been registered
            services.AddTransient<BuildVersionServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<WestWindContext>();
                // We need to create an uinstance of the service class (BuildVersionServices)
                // supplying the contect reference to the service class, and then we return the 
                // service class instance, for the we return a newbuildversionservice using out context
                return new BuildVersionServices(context);
            });

            services.AddTransient<RegionServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<WestWindContext>();
                return new RegionServices(context);
            });
        }
    }
}
