using LinkedIn_Applier.Entities;

namespace LinkedIn_Applier.Business.Abstract
{
    public abstract class AbstractSettingService
    {
        public abstract Task<bool> SetSettings(Setting setting);
        public abstract Task<Setting> GetSettings();
    }
}
