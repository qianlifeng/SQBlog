using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Domain.Model;
using BDDD.Repository;

namespace SQBlog.Domain.Repository
{
    public interface IBlogRepository : IRepository<Blog>
    {
        /// <summary>
        /// 获得数据库中的第一条记录。
        /// <remarks>对于BlogRepository有特殊意义，
        /// 因为一般来说BlogrReposiotory中只会存在一条博客信息</remarks>
        /// </summary>
        /// <returns>博客对象</returns>
        Blog GetFirstItem();
    }
}
