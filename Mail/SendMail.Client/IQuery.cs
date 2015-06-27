namespace SendMail.Client
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using SendMail.Client.Mail.Views;

    #endregion

    public interface IQuery
    {
        #region Public Methods and Operators

        IEnumerable<MailView> Get<TKey>(int pageSize, int page, out int rowsCount, Expression<Func<MailView, bool>> where, Expression<Func<MailView, TKey>> orderBy, bool asc = true);

        IEnumerable<MailView> Get<TKey>(int pageSize, int page, out int rowsCount, Expression<Func<MailView, TKey>> orderBy, bool asc = true);

        IEnumerable<MailView> Get(Expression<Func<MailView, bool>> where);

        IEnumerable<MailView> Get<TKey>(Expression<Func<MailView, bool>> where, Expression<Func<MailView, TKey>> orderBy, bool asc = true);

        MailView Get(Guid id);

        #endregion
    }
}