using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Domain.Repository;
using BDDD.Repository.NHibernate;
using SQBlog.Domain.Model;
using BDDD.Repository;
using BDDD.Specification;

namespace SQBlog.Repository.NHibernate
{
    public class CategoryRepository : NHibernateRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IRepositoryContext context)
            : base(context)
        { }


        public Category GetCategory(string Name)
        {
            return GetAll(Specification<Category>.Eval(o => o.Name == Name)).First();
        }
    }
}
