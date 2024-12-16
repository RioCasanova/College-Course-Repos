#region Additional Namespace
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.BLL;
using WestWindSystem.DAL;
#endregion


namespace WestWindSystem
{
    public static class WWBackendExtensions
    {
        public static void WWBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            //  Within this method, we will register all the services that will
            //      be used by the system (context setup) and will be provided by
            //      the system.
            services.AddDbContext<WestWindContext>(options);

            //  register the service classes

            //  add any business logic layer class to the service collection so our 
            //      web app has access to the methods (services) within the BLL class

            //  The argument for the AddsTransient is called a factory
            //  Basically what you are adding is a localize method
            services.AddTransient<BuildVersionServices>((ServiceProvider) =>
            {
                //  get the dbcontext class that has been registered
                var context = ServiceProvider.GetService<WestWindContext>();
                //  create an instance of the service class (BuidVersionServices) supplying
                //      the context reference to the service class
                //  return the service class instance
                return new BuildVersionServices(context);
            }
             );
            services.AddTransient<RegionServices>((ServiceProvider) =>
            {
                //  get the dbcontext class that has been registered
                var context = ServiceProvider.GetService<WestWindContext>();
                //  create an instance of the service class (RegionServices) supplying
                //      the context reference to the service class
                //  return the service class instance
                return new RegionServices(context);
            }
             );
            services.AddTransient<TerritoryServices>((ServiceProvider) =>
                {
                    //  get the dbcontext class that has been registered
                    var context = ServiceProvider.GetService<WestWindContext>();
                    //  create an instance of the service class (TerritoryServices) supplying
                    //      the context reference to the service class
                    //  return the service class instance
                    return new TerritoryServices(context);
                }
            );
        }
    }
}
