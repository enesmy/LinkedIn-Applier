using LinkedIn_Applier.Business.Abstract;
using LinkedIn_Applier.DataAccess.Abstract;
using LinkedIn_Applier.DataAccess.Concrete;
using LinkedIn_Applier.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinkedIn_Applier.Business.Concrete
{
    public class MailManager : AbstractMailService
    {
        private IAsyncRepository<Mail> repository = null;
        public MailManager(DbContext context)
        {
            this.repository = new GenericRepository<Mail>(context);
        }
        public override async Task<Mail> AddMail(Mail mail)
        {
            await repository.Add(mail);
            return mail;
        }

        public override async Task<bool> ExistMail(string email)
        {
            var mail = await repository.FirstOrDefault(o => o.EMailAdress == email);
            if (mail == null) return false;
            else return true;
        }

        public override async Task<List<Mail>> GetAllWaitingMails()
        {
            var result = await repository.GetWhereWithNoTrack(o => o.EmailSent != true );
            return result.ToList();
        }

        public override async Task<bool> SetMailSent(int mailID)
        {
            var mail = await repository.GetByPrimaryKey(mailID);
            if (mail == null) return false;
            mail.EmailSent = true;
            await repository.Update(mail);
            return true;
        }
    }
}
