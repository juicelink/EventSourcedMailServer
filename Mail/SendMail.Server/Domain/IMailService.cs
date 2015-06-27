namespace SendMail.Server.Domain
{
    using System.Threading.Tasks;

    using SendMail.Server.Domain.MailAgg;
    using SendMail.Server.Domain.MailAgg.State;

    public interface IMailService
    {
        Task<SendMailResult> Send(MailRequest mail);
    }
}