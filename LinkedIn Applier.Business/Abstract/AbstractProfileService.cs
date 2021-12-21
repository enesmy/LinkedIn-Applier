using LinkedIn_Applier.Entities;

namespace LinkedIn_Applier.Business.Abstract
{
    public abstract class AbstractProfileService
    {
        public abstract Task<Profile> GetProfileFromProfileID(int profileID);
        public abstract Task<Profile> SaveProfile(Profile profile);
        public abstract Task<List<Profile>> GetAllProfiles();
        public abstract Task<List<VMProfile>> GetAllProfilesWithLocations();
        public abstract Task<(bool IsSuccess, string Message)> DeleteProfile(int profileID);
    }
}
