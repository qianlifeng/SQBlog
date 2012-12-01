using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using SQBlog.Repository.NHibernate.FluentNHibernateMap;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;

namespace SQBlog.UnitTest
{
    [TestClass]
    public class DBGenerate
    {
        [TestMethod]
        public void CreateDB()
        {
            Configuration nhibernateCfg = Fluently.Configure()
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

            SchemaExport schemaExport = new SchemaExport(nhibernateCfg);
            schemaExport.Execute(false, true, false);
        }
    }
}
