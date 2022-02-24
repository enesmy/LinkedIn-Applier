using LinkedIn_Applier.Business.Abstract;
using LinkedIn_Applier.DataAccess.Abstract;
using LinkedIn_Applier.DataAccess.Concrete;
using LinkedIn_Applier.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkedIn_Applier.Business.Concrete
{
    public class ProfileManager : AbstractProfileService
    {
        private IAsyncRepository<Profile> repository = null;
        private IAsyncRepository<Location> repositoryLocation = null;

        public ProfileManager(DbContext context)
        {
            this.repository = new GenericRepository<Profile>(context);
            this.repositoryLocation = new GenericRepository<Location>(context);
        }
        public override async Task<(bool IsSuccess, string Message)> DeleteProfile(int profileID)
        {
            var foundProfile = await repository.GetByPrimaryKey(profileID);
            if (foundProfile != null) await repository.Remove(foundProfile.ProfileID);
            else return (false, "Profile not exist!");
            return (true, "Profile removed!");
        }

        public override async Task<List<Profile>> GetAllProfiles() =>
            (await repository.GetWhere(o => !o.IsDeleted)).ToList();

        public override async Task<List<VMProfile>> GetAllProfilesWithLocations()
        {
            var profiles = await GetAllProfiles();
            var Locations = (await repositoryLocation.GetWhereWithNoTrack(o => !o.IsDeleted)).ToList();

            var result = (from profile in profiles
                          join location in Locations on profile.ProfileID equals location.ProfileID into profilelocation
                         where !profile.IsDeleted
                          select new VMProfile()
                          {
                              ProfileID = profile.ProfileID,
                              CVLocation = profile.CVLocation,
                              DeleteDateTime = profile.DeleteDateTime,
                              IsDeleted = profile.IsDeleted,
                              MailSubject = profile.MailSubject,
                              ProfileName = profile.ProfileName,
                              ProfileShortName = profile.ProfileShortName,
                              WorkType = profile.WorkType,
                              Locations = profilelocation.ToList()
                          }
                          ).ToList();
            return result;
        }

        public override async Task<Profile> GetProfileFromProfileID(int profileID) =>
            await repository.GetByPrimaryKey(profileID);

        public override async Task<Profile> SaveProfile(Profile profile)
        {
            if (profile.ProfileID > 0) await repository.Update(profile);
            else await repository.Add(profile);

            return profile;
        }
    }
}
