namespace SendMail.EFReadModel
{
    #region using

    using System.Data.Entity.ModelConfiguration;

    using SendMail.Client.Mail.Views;

    #endregion

    public class MailViewConfiguration : EntityTypeConfiguration<MailView>
    {
        #region Constructors and Destructors

        public MailViewConfiguration()
        {
            this.HasKey(m => m.Id);
        }

        #endregion
    }
}