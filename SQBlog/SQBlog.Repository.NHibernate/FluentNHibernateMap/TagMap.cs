using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Domain.Model;
using FluentNHibernate.Mapping;

namespace SQBlog.Repository.NHibernate.FluentNHibernateMap
{
    public class TagMap:ClassMap<Tag>
    {
        public TagMap()
        {
            Id(m => m.ID).GeneratedBy.Guid();
            Map(m => m.Name).Not.Nullable();
            Map(m => m.Description);
        }
    }
}
