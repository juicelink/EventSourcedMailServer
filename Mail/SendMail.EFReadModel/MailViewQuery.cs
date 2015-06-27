namespace SendMail.EFReadModel
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using SendMail.Client;
    using SendMail.Client.Mail.Views;

    #endregion

    public class MailViewQuery : IQuery
    {
        #region Public Methods and Operators

        public IEnumerable<MailView> Get<TKey>(int pageSize, int page, out int rowsCount, Expression<Func<MailView, bool>> where, Expression<Func<MailView, TKey>> orderBy, bool asc = true)
        {
            using (var context = new SendMailContext())
            {
                var result = context.MailViews.Where(where);
                rowsCount = result.Count();
                result = asc ? result.OrderBy(orderBy) : result.OrderByDescending(orderBy);
                return GetPaged(result, pageSize, page, rowsCount);
            }
        }

        public IEnumerable<MailView> Get<TKey>(int pageSize, int page, out int rowsCount, Expression<Func<MailView, TKey>> orderBy, bool asc = true)
        {
            using (var context = new SendMailContext())
            {
                IQueryable<MailView> result = context.MailViews;
                rowsCount = result.Count();
                if (rowsCount <= pageSize || page < 1)
                {
                    page = 1;
                }
                result = asc ? result.OrderBy(orderBy) : result.OrderByDescending(orderBy);
                return GetPaged(result, pageSize, page, rowsCount).ToList();
            }
        }

        public IEnumerable<MailView> Get(Expression<Func<MailView, bool>> where)
        {
            using (var context = new SendMailContext())
            {
                return context.MailViews.Where(where).ToList();
            }
        }

        public IEnumerable<MailView> Get<TKey>(Expression<Func<MailView, bool>> where, Expression<Func<MailView, TKey>> orderBy, bool asc = true)
        {
            using (var context = new SendMailContext())
            {
                var result = context.MailViews.Where(where);
                return (asc ? result.OrderBy(orderBy) : result.OrderByDescending(orderBy)).ToList();
            }
        }

        public MailView Get(Guid id)
        {
            using (var context = new SendMailContext())
            {
                return context.MailViews.Find(id);
            }
        }

        #endregion

        #region Methods

        private static IEnumerable<MailView> GetPaged(IQueryable<MailView> query, int pageSize, int page, int rowsCount)
        {
            if (pageSize <= 0)
            {
                pageSize = 20;
            }
            if (rowsCount <= pageSize || page < 1)
            {
                page = 1;
            }
            var excludedRows = (page - 1) * pageSize;
            return query.Skip(excludedRows).Take(pageSize);
        }

        #endregion
    }
}