#nullable disable
#region Additional Namespaces
using TrainWatchSystem.DAL;
using TrainWatchSystem.Entities;
#endregion


namespace TrainWatchSystem.BLL
{
    public class TrainWatchServices
    {
        #region Setup of the CONTEXT connection
        private readonly TrainWatchContext _context;
        #endregion

        internal TrainWatchServices(TrainWatchContext registeredContext)
        {
            _context = registeredContext;
        }
        #region Services: Query
        public DbVersion GetDbVersion()
        {
            DbVersion info = _context.dbBuildVersions.FirstOrDefault();
            return info;
        }
        #endregion
    }
}
