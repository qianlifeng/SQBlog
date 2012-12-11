using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Config;
using BDDD.Application;
using Microsoft.Practices.Unity;
using BDDD.Repository.NHibernate;
using BDDD.Repository;
using SQBlog.Application;
using SQBlog.Application.Implementation;
using SQBlog.Domain.Repository;
using SQBlog.Repository.NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using SQBlog.Repository.NHibernate.FluentNHibernateMap;

namespace SQBlog.UnitTest
{
    public class Common
    {
        public static void StartApp()
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
        public static Configuration GetNHibernateConnnectInfo()
        {
            return Fluently.Configure()
                  .Database(
                      FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
                          .ConnectionString(s => s.Server("182.16.3.18")
                                  .Database("a0216215226")
                                  .Username("a0216215226").Password("scott"))
                                  .ShowSql()
                  )
                  .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(BlogMap).Assembly)
                      .Conventions.Add(ForeignKey.EndsWith("Id"))
                      )
                  .BuildConfiguration();
        }
    }
}
