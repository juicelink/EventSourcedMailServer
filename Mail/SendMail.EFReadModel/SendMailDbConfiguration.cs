using System;

namespace SendMail.EFReadModel
{
    #region using

    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using SendMail.EFReadModel.Properties;

    #endregion

    public class SendMailDbConfiguration : DbConfiguration
    {
        private Type _Hack = typeof (System.Data.Entity.SqlServer.SqlProviderServices);
        
        #region Constructors and Destructors

        public SendMailDbConfiguration()
        {
            this.SetDatabaseInitializer(new CreateDatabaseIfNotExists<SendMailContext>());
            this.SetDefaultConnectionFactory(new SqlConnectionFactory(@"Data Source=CMAPPA1287DEV\IS_CRMFINTRN_DEV;Initial Catalog=SendMail;Integrated Security=SSPI;"));
        }

        #endregion
    }
}