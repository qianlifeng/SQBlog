using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD;

namespace SQBlog.Domain.Model
{
    public class Article : IAggregateRoot
    {
        #region - 属性 -

        public virtual string Title { get; protected set; }
        public virtual string Content { get; protected set; }
        /// <summary>
        /// 内容简介，用于显示在首页
        /// </summary>
        public virtual string ContentBio { get; protected set; }
        public virtual DateTime PublishDate { get; protected set; }
        public virtual DateTime LastEditDate { get; protected set; }

        public virtual Category Category { get; protected set; }
        public virtual IList<Tag> Tags {get;protected set;}

        #endregion

        public Article() { }
        public Article(string title,string content,string contentBio)
        {
            Title =  title;
            Content = content;
            ContentBio = contentBio;
            LastEditDate = PublishDate = DateTime.Now;
        }


        #region - 方法 -

        /// <summary>
        /// 修改文章分类
        /// </summary>
        /// <param name="newCategory">新分类</param>
        public virtual void ChangeCategory(Category newCategory)
        {
            Category = newCategory;
        }

        public virtual void AddTag(Tag tag)
        {
            if (Tags.Where(o => o.Name == tag.Name).Count() > 0)
                throw new ArgumentException("已经存在相同名称的Tag");
            Tags.Add(tag);
        }

        public virtual void RemoveTag(Tag tag)
        {
            Tag t = Tags.Where(o => o.Name == tag.Name).First();
            if (t == null) throw new ArgumentException("当前文章中不存在 {0} 标签", tag.Name);

            Tags.Remove(t);
        }

        #endregion

        #region IAggregateRoot 接口

        public virtual Guid ID
        {
            get;
            set;
        }

        public virtual bool Equals(IEntity other)
        {
            return other.ID == ID;
        }

        #endregion
    }
}
