using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using SQBlog.Repository.NHibernate.FluentNHibernateMap;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using BDDD.Config;
using BDDD.Application;
using BDDD.Repository.NHibernate;
using SQBlog.Domain.Repository;
using SQBlog.Application;
using SQBlog.Application.Implementation;
using SQBlog.Repository.NHibernate;
using Microsoft.Practices.Unity;
using BDDD.Repository;
using BDDD.ObjectContainer;
using SQBlog.Domain.Model;
using SQBlog.Infrastructure;

namespace SQBlog.UnitTest
{
    [TestClass]
    public class DBGenerate
    {
        [ClassInitialize]
        public static void InitApp(TestContext context)
        {
            Common.StartApp();
        }


        //[TestMethod]
        public void CreateDB()
        {
            SchemaExport schemaExport = new SchemaExport(Common.GetNHibernateConnnectInfo());
            schemaExport.Execute(false, true, false);

            CreateBlog();
        }

        public void CreateBlog()
        {
            IRepositoryContext repositoryContext = ServiceLocator.Instance.GetService<IRepositoryContext>();
            IBlogRepository blogRepository = ServiceLocator.Instance.GetService<IBlogRepository>();

            Blog blog = new Blog("Scott Qian",string.Empty,"Default",DES.DesEncrypt("123456"));
            blogRepository.Add(blog);
            repositoryContext.Commit();
        }
    }
}
