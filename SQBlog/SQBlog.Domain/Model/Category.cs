using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD;

namespace SQBlog.Domain.Model
{
    public class Category : IAggregateRoot
    {
        #region - 属性 -

        public virtual string Name { get; protected set; }

        public virtual string Description { get; protected set; }

        #endregion

        #region - 构造函数 -

        public Category() { }

        public Category(string name, string desc)
        {
            Name = name;
            Description = desc;
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
