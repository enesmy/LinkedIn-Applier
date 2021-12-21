using LinkedIn_Applier.Business.Abstract;
using LinkedIn_Applier.DataAccess.Abstract;
using LinkedIn_Applier.DataAccess.Concrete;
using LinkedIn_Applier.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkedIn_Applier.Business.Concrete
{
    public class LocationManager : AbstractLocationService
    {
        private IAsyncRepository<Location> repository = null;
        public LocationManager(DbContext context)
        {
            this.repository = new GenericRepository<Location>(context);
        }
        public override async Task<Location> AddLocation(int profileID, string loc)
        {
            Location location = new Location()
            {
                IsDeleted = false,
                Place = loc,
                ProfileID = profileID
            };
            await repository.Add(location);
            return location;
        }

        public override async Task<List<Location>> GetAllLocationsFromProfileID(int profileID) =>
            (await repository.GetWhereWithNoTrack(o => o.ProfileID == profileID)).ToList();


        public override async Task<(bool IsSuccess, string Message)> RemoveLocation(int locationID)
        {
            var foundLocation = await repository.GetByPrimaryKey(locationID);
            if (foundLocation != null) await repository.HardRemove(foundLocation.LocationID);
            else return (false, "Location not exist!");
            return (true, "Location removed!");
        }
    }
}
