#nullable disable
#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class TerritoryServices
    {
        #region Setup of the context connection
        private readonly WestWindContext _context;
        #endregion

        //  constructor to create an instance of the registered context class
        internal TerritoryServices(WestWindContext regContext)
        {
            _context = regContext;
        }
        #region Services: Query
        public List<Territory> GetByPartialDescription(string partialDescription)
        {
            IEnumerable<Territory> info = _context.Territories
                .Where(x => x.TerritoryDescription.Contains(partialDescription))
                .OrderBy(x => x.TerritoryDescription);
            return info.ToList();
        }

        //  Query by region ID (number)
        public List<Territory> GetByRegion(int regionID)
        {
            return _context.Territories
                .Where(x => x.RegionID == regionID)
                .OrderBy(x => x.TerritoryDescription).ToList();
        }
        #endregion
    }
}
