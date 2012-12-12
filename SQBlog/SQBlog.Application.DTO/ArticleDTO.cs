using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Domain.Model;
using System.Runtime.Serialization;

namespace SQBlog.Application.DTO
{
    [DataContract]
    public class ArticleDTO : IDataTransferObject<Article>
    {
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

        public void MapFrom(Article domainModel)
        {
            Title = domainModel.Title;
            Content = domainModel.Content;
            ContentBio = domainModel.ContentBio;
            PublishDate = domainModel.PublishDate;
            LastEditDate = domainModel.LastEditDate;
            Category = domainModel.Category.Name;
            Tags = domainModel.Tags.Select(o => o.Name).ToList();
        }

        public Article MapTo()
        {
            Article article = new Article(Title, Content, ContentBio);
            //todo: map
            return article;
        }
    }
}
