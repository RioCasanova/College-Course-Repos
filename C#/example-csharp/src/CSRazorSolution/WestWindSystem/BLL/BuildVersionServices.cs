#nullable disable
#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class BuildVersionServices
    {
        #region Setup of the context connection
        private readonly WestWindContext _context;
        #endregion

        //  constructor to create an instance of the registered context class
        internal BuildVersionServices(WestWindContext regContext)
        {
            _context = regContext;
        }
        #region Services: Query
        //  Create a method (services) that will retrieve the BuildVersion record
        //  This will be called from the web app (PageModel file), thus it needs to be public
        //  This becomes part of the class library's (application library) public interface.
        public BuildVersion GetBuildVersion()
        {
            //  Going to your context instance (class), use the property (DbSet) for
            //      BuildVersion data
            //  Using this property will retrieve your data from the database.
            //  The query will get the first record from the database collection (records)
            //      and return it.
            //  If no data was returned from SQL for the query, the returned value will be null.

            BuildVersion info = _context.BuildVersions.FirstOrDefault();
            return info;

        }

        #endregion
    }
}
