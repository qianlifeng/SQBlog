using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SQBlog.Domain.Model;

namespace SQBlog.Repository.NHibernate.FluentNHibernateMap
{
    public class BlogMap : ClassMap<Blog>
    {
        public BlogMap()
        {
            Id(m => m.ID).GeneratedBy.Guid();
            Map(m => m.Title);
            Map(m => m.SubTitle);
            Map(m => m.Theme);
            Map(m => m.Password);
        }
    }
}
