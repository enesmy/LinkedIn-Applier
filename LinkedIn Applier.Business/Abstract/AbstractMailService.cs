using LinkedIn_Applier.Entities;

namespace LinkedIn_Applier.Business.Abstract
{
    public abstract class AbstractMailService
    {
        public abstract Task<Mail> AddMail(Mail mail);
        public abstract Task<bool> SetMailSent(int mailID);
        public abstract Task<bool> ExistMail(string email);
        public abstract Task<List<Mail>> GetAllWaitingMails();
    }
}
