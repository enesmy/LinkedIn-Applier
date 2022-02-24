using LinkedIn_Applier.Entities;

namespace LinkedIn_Applier.Business.Abstract
{
    public abstract class AbstractLocationService
    {
        public abstract Task<Location> AddLocation(int profileID, string loc);
        public abstract Task<(bool IsSuccess, string Message)> RemoveLocation(int locationID);
        public abstract Task<List<Location>> GetAllLocationsFromProfileID(int profileID);
        public abstract Task IncriseRate(Location location);

    }
}
