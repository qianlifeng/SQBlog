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
            IConfigSource configSource = new AppConfigSource();
            App application = AppRuntime.Create(configSource);
            application.AppInitEvent += new App.AppInitHandle(application_AppInitEvent);
            application.Start();
        }

        static void application_AppInitEvent(IConfigSource source, BDDD.ObjectContainer.IObjectContainer objectContainer)
        {
            UnityContainer container = objectContainer.GetRealObjectContainer<UnityContainer>();

            container.RegisterType<INHibernateConfiguration, NHibernateConfiguration>(new ContainerControlledLifetimeManager(),
              new InjectionConstructor(GetNHibernateConnnectInfo()));
            container.RegisterType<IRepositoryContext, NHibernateContext>(new PerThreadLifetimeManager(),
               new InjectionConstructor(new ResolvedParameter<INHibernateConfiguration>()));

            //Application and Repository
            container.RegisterType<IBlogApplication, BlogApplication>();
            container.RegisterType<IBlogRepository, BlogRepository>();
        }

        /// <summary>
        /// 获得数据库链接信息
        /// </summary>
        /// <returns></returns>
        static Configuration GetNHibernateConnnectInfo()
        {
            return Fluently.Configure()
                  .Database(
                      FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
                          .ConnectionString(s => s.Server("localhost")
                                  .Database("SQBlog")
                                  .TrustedConnection())
                                  .ShowSql()
                  )
                  .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(BlogMap).Assembly)
                      .Conventions.Add(ForeignKey.EndsWith("Id"))
                      )
                  .BuildConfiguration();
        }

        [TestMethod]
        public void CreateDB()
        {
            SchemaExport schemaExport = new SchemaExport(GetNHibernateConnnectInfo());
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
