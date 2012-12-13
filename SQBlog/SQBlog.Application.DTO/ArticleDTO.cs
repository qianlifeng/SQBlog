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
    public class ArticleDTO : IDataTransferObject<Article>
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string ContentBio { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public DateTime LastEditDate { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public IList<string> Tags { get; set; }
        [DataMember]
        public bool Private { get; set; }
        [DataMember]
        public virtual bool IsDraft { get; protected set; }
        /// <summary>
        /// 被喜欢次数
        /// </summary>
        [DataMember]
        public virtual int LoveCount { get; protected set; }

        public ArticleDTO() { }

        public ArticleDTO(Article article)
        {
            MapFrom(article);
        }

        public void MapFrom(Article domainModel)
        {
            Id = domainModel.ID;
            Title = domainModel.Title;
            Content = domainModel.Content;
            ContentBio = domainModel.ContentBio;
            PublishDate = domainModel.PublishDate;
            LastEditDate = domainModel.LastEditDate;
            Category = domainModel.Category.Name;
            Private = domainModel.Private;
            IsDraft = domainModel.IsDraft;
            LoveCount = domainModel.LoveCount;
            Tags = domainModel.Tags.Select(o => o.Name).ToList();
        }

        public Article MapTo()
        {
            //此处的转换放到具体的Application层中实施
            //因为不同的事物下，转换不同
            throw new NotImplementedException();
        }
    }
}
