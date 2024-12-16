#nullable disable
using TrainWatchSystem.DAL;
using TrainWatchSystem.Entities;

namespace TrainWatchSystem.BLL
{
    public class RollingStockServices
    {
        #region Setup of the CONTEXT connection
        private readonly TrainWatchContext _context;
        #endregion

        internal RollingStockServices(TrainWatchContext registeredContext)
        {
            _context = registeredContext;
        }

        #region Services: Query
        public List<RollingStock> GetByPartialDescription(string partialDescription)
        {
            IEnumerable<RollingStock> info = _context.rollingStock
                .Where(x => x.ReportingMark.Contains(partialDescription));
            return info.ToList();
        }
        public List<RollingStock> RailCar_GetByID(int? railCarTypeID)
        {
            IEnumerable<RollingStock> info = _context.rollingStock
                                   .Where(aColectionRow => aColectionRow.RailCarTypeID == railCarTypeID);
            return info.ToList();
        }
        #endregion
    }

}
