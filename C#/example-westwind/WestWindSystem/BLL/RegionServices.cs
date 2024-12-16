#region Additional Namespaces
using System.Collections.Generic;
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion
#nullable disable


namespace WestWindSystem.BLL
{
    public class RegionServices
    {
        #region Setup of the context connection
        private readonly WestWindContext _context;
        #endregion

        internal RegionServices(WestWindContext regContext)
        {
            _context = regContext;
        }
        #region Services: Query

        public Region Region_GetByID(int regionID)
        {
            Region info = _context.regions
                                  .Where(aCollectionRow => aCollectionRow.RegionId == regionID)
                                  .FirstOrDefault();
            return info;
        }
        // Get all the records of the SQL REgion table and return as a list
        // List<T>
        public List<Region> Region_List()
        {
            //LINQ queries use two generic collection types
            //IQueryable - This is the data collection returned from SQL
            // IEnummerable - This is the data collection in local memory
            // You can convert either of these collections to a List<T> using .ToList()

            IEnumerable<Region> info = _context.regions // DbSet<Region>
                                        .OrderBy(x => x.RegionDescription); //.Dump();
            return info.ToList();

            // One could convert the return data collection to a List<T> by placing the conversion method directly 
            // on your query
            //List<Region> info = _context.regions// DbSet<Region>
            //                .OrderBy(x: Region => x.RegionDescription).ToList();
            //return info;
        }
        #endregion
        // Ensure that the services are being linked in the backend extensions file of the linked project, in this case, WestWindSystem
    }
}
