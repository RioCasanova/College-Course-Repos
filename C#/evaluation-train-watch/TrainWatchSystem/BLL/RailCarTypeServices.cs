#nullable disable
using TrainWatchSystem.DAL;
using TrainWatchSystem.Entities;

namespace TrainWatchSystem.BLL
{
    public class RailCarTypeServices
    {
        #region Setup of the CONTEXT connection
        private readonly TrainWatchContext _context;
        #endregion

        internal RailCarTypeServices(TrainWatchContext registeredContext)
        {
            _context = registeredContext;
        }

        #region Services: Query
        public List<RailCarTypes> RailCarTypes_List()
        {
            IEnumerable<RailCarTypes> info = _context.railCarTypes
                                        .OrderBy(x => x.Name);
            return info.ToList();
        }
        #endregion
    }
}
