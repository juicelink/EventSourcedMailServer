namespace SendMail.EFReadModel
{
    #region using

    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using SendMail.Client.Mail.Views;

    #endregion

    public class SendMailContext : DbContext
    {
        public SendMailContext() : base("SendMail")
        {
            
        }
        
        #region Public Properties

        public DbSet<MailView> MailViews { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(p => p.IsUnicode(false));

            modelBuilder.Configurations.Add(new MailViewConfiguration());
        }

        #endregion
    }
}