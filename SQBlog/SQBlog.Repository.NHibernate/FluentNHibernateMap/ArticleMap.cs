using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Domain.Model;
using FluentNHibernate.Mapping;

namespace SQBlog.Repository.NHibernate.FluentNHibernateMap
{
    public class ArticleMap : ClassMap<Article>
    {

        public ArticleMap()
        {
            Id(m => m.ID).GeneratedBy.Guid();
            Map(m => m.Title).Not.Nullable();
            Map(m => m.Content);
            Map(m => m.ContentBio);
            Map(m => m.PublishDate);
            Map(m => m.LastEditDate);
            References(m => m.Category);
        }
    }
}
