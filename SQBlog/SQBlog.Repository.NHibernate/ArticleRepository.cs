using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Repository.NHibernate;
using SQBlog.Domain.Model;
using SQBlog.Domain.Repository;
using BDDD.Repository;

namespace SQBlog.Repository.NHibernate
{
    public class ArticleRepository : NHibernateRepository<Article>, IArticleRepository
    {
        public ArticleRepository(IRepositoryContext context)
            : base(context)
        { }

    }
}
