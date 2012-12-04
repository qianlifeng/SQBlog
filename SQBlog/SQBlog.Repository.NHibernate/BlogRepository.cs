using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Domain.Repository;
using SQBlog.Domain.Model;
using BDDD.Repository.NHibernate;
using BDDD.Repository;

namespace SQBlog.Repository.NHibernate
{
    public class BlogRepository : NHibernateRepository<Blog>, IBlogRepository
    {
        public BlogRepository(IRepositoryContext context)
            : base(context)
        { }


        public Blog GetFirstItem()
        {
            return GetAll().FirstOrDefault();
        }
    }
}
