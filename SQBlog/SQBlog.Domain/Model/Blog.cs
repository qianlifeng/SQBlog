using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD;

namespace SQBlog.Domain.Model
{
    public class Blog : IAggregateRoot
    {
        #region - 属性 -

        public virtual string Title { get; protected set; }

        public virtual string SubTitle { get; protected set; }

        public virtual string Theme { get; protected set; }

        /// <summary>
        /// 博客登录密码，本博客没有多用户概念，所以设计的时候
        /// 只需要密码登录即可，登录即管理员
        /// </summary>
        public virtual string Password { get; protected set; }

        #endregion

        #region - 构造函数 -

        public Blog() { }

        public Blog(string title, string subTitle, string theme, string password)
        {
            Title = title;
            SubTitle = subTitle;
            Theme = theme;
            Password = password;
        }

        #endregion

        #region - 方法 -

        public virtual void SetBlogTitle(string newTitle)
        {
            Title = newTitle;
        }

        public virtual void SetBlogSubTitle(string subTitle)
        {
            SubTitle = subTitle;
        }

        public virtual void SetBlogTheme(string themeName)
        {
            Theme = themeName;
        }

        /// <summary>
        /// 校验登录密码是否正确
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public virtual bool CheckPassword(string pwd)
        {
            return Password == pwd;
        }

        public virtual void ChangeBlogPassword(string pwd)
        {
            Password = pwd;
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
