#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion
#nullable disable


namespace WestWindSystem.BLL
{
    public class BuildVersionServices
    {
        #region Setup of the context connection
        private readonly WestWindContext _context;
        #endregion

        // Create a constructor to create an instance of the registered context class
        internal BuildVersionServices(WestWindContext regContext)
        {
            _context = regContext;
        }

        #region Services: Query

        // We want to create a method which are services which will retrieve the buildversion record,
        // this will be called from the web app (PageModel file), thus it needs to be public.
        // This becomes part of the class libraries (application library) public interface.
        public BuildVersion GetBuildVersion()
        {
            // Going to your context instance which is a class we use the property (DbSet) for
            // the BuildVersion data. Using this property we will retrieve the data from the database,
            // the query will get the first record from the databases collection (records) and return it.
            // If no data was returned from SQL for the query the returned value will be null. 
            BuildVersion info = _context.buildVersions.FirstOrDefault();
            return info;
        }
        #endregion
    }
}
