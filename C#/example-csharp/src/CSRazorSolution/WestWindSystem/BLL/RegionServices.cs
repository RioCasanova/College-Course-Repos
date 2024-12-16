#nullable disable
#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class RegionServices
    {
        #region Setup of the context connection
        private readonly WestWindContext _context;
        #endregion

        //  constructor to create an instance of the registered context class
        internal RegionServices(WestWindContext regContext)
        {
            _context = regContext;
        }
        #region Services: Query
        //  Create a method (services) that will retrieve the BuildVersion record
        //  This will be called from the web app (PageModel file), thus it needs to be public
        //  This becomes part of the class library's (application library) public interface.
        public Region Region_GetByID(int regionID)
        {
            //  Going to your context instance (class), use the property (DbSet) for
            //      Region data
            //  Using this property will retrieve your data from the database.
            //  The query will get the first record from the database collection (records)
            //      and return it.
            //  If no data was returned from SQL for the query, the returned value will be null.

            Region info = _context.Regions
                                   .Where(aColectionRow => aColectionRow.RegionID == regionID)
                                   .FirstOrDefault();
            return info;
        }

        //  Get all the records of the SQL Region table
        //  Return as a List<T>
        public List<Region> Region_List()
        {
            //  Linq querys use two generic collection types
            //  IQueryable - This is the data collection returned from SQL
            //  IEnumerable -   This is the data collection in local memory
            //  You can convert either of these collections to a List<T> using .ToList()
            IEnumerable<Region> info = _context.Regions
                                        .OrderBy(x => x.RegionDescription);
            return info.ToList();

            //  One could convert the returned data collection to a List<T> by
            //      placing the conversion method directly on your query
            //List<Region> info = _context.Regions
            //    .OrderBy(x => x.RegionDescription).ToList();
            //return info

            //  James way of returning data.
            //  We do not make any changes to info so we can just return the list.
            //return _context.Regions
            //    .OrderBy(x => x.RegionDescription).ToList();

        }


        #endregion
    }
}
