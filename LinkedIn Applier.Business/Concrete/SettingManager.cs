using LinkedIn_Applier.Business.Abstract;
using LinkedIn_Applier.DataAccess.Abstract;
using LinkedIn_Applier.DataAccess.Concrete;
using LinkedIn_Applier.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn_Applier.Business.Concrete
{
    public class SettingManager : AbstractSettingService
    {
        private IAsyncRepository<Setting> repository = null;
        public SettingManager(DbContext context)
        {
            this.repository = new GenericRepository<Setting>(context);
        }

        public override async Task<bool> SetSettings(Setting setting)
        {
            var result = await repository.GetAll();
            if (result.Count() > 0)
                foreach (var item in result)
                {
                    await repository.HardRemove(item.SettingID);
                }
            await repository.Add(setting);
            return true;
        }

        public override async Task<Setting> GetSettings() =>
             await repository.FirstOrDefault(o => true);
    }
}
