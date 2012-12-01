using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Domain.Model;
using System.Runtime.Serialization;
using SQBlog.Domain.Repository;
using BDDD.ObjectContainer;

namespace SQBlog.Application.DTO
{
    [DataContract]
    public class BlogDTO : IDataTransferObject<Blog>
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string SubTitle { get; set; }
        [DataMember]
        public string Theme { get; set; }

        public void MapFrom(Blog domainModel)
        {
            ID = domainModel.ID;
            Title = domainModel.Title;
            SubTitle = domainModel.SubTitle;
            Theme = domainModel.Theme;
        }

        public Blog MapTo()
        {
            if (ID == Guid.Empty)
            {
                return new Blog(Title, SubTitle, Theme, "");
            }

            Blog blog = ServiceLocator.Instance.GetService<IBlogRepository>().GetByKey(ID);
            if (blog == null)
                throw new ArgumentException("不存在此ID的Blog对象");

            blog.SetBlogTitle(Title);
            blog.SetBlogSubTitle(SubTitle);
            blog.SetBlogTheme(Theme);
            return blog;
        }
    }
}
