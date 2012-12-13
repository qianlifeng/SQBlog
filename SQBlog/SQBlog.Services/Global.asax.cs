using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using BDDD.Config;
using BDDD.Application;
using Microsoft.Practices.Unity;
using SQBlog.Application;
using SQBlog.Application.Implementation;
using BDDD.Repository;
using BDDD.Repository.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Cfg;
using SQBlog.Repository.NHibernate.FluentNHibernateMap;
using SQBlog.Domain.Repository;
using SQBlog.Repository.NHibernate;

namespace SQBlog.Services
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            IConfigSource configSource = new AppConfigSource();
            App application = AppRuntime.Create(configSource);
            application.AppInitEvent += new App.AppInitHandle(application_AppInitEvent);
            application.Start();
        }

        void application_AppInitEvent(IConfigSource source, BDDD.ObjectContainer.IObjectContainer objectContainer)
        {
            UnityContainer container = objectContainer.GetRealObjectContainer<UnityContainer>();

            container.RegisterType<INHibernateConfiguration, NHibernateConfiguration>(
              new InjectionConstructor(GetNHibernateConnnectInfo()));
            container.RegisterType<IRepositoryContext, NHibernateContext>(
               new InjectionConstructor(new ResolvedParameter<INHibernateConfiguration>()));

            //Application and Repository
            container.RegisterType<IBlogApplication, BlogApplication>();
            container.RegisterType<IBlogRepository, BlogRepository>();
            container.RegisterType<IArticleApplication, ArticleApplication>();
            container.RegisterType<IArticleRepository, ArticleRepository>();
        }

        /// <summary>
        /// 获得数据库链接信息
        /// </summary>
        /// <returns></returns>
        Configuration GetNHibernateConnnectInfo()
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

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}