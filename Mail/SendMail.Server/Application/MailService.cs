namespace SendMail.Server.Application
{
    #region using

    using System;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using SeedWork.Utils;

    using SendMail.Server.Domain;
    using SendMail.Server.Domain.MailAgg;
    using SendMail.Server.Domain.MailAgg.State;
    using SendMail.Server.Properties;

    #endregion

    public class MailService : IMailService
    {
        #region Public Methods and Operators

        public async Task<SendMailResult> Send(MailRequest mail)
        {
            try
            {
                using (var smtp = new SmtpClient(Settings.Default.smtp))
                {
                    var message = new MailMessage { From = new MailAddress(mail.From), Subject = mail.Subject, Body = mail.Body };
                    foreach (var addr in mail.To)
                    {
                        message.To.Add(addr);
                    }

                    message.IsBodyHtml = true;

                    await smtp.SendMailAsync(message);
                }
                return new SendMailResult(true, null);
            }
            catch (Exception ex)
            {
                typeof(MailService).Log().Error(ex, "error sending message");
                return new SendMailResult(false, ex.Message);
            }
        }

        #endregion
    }
}