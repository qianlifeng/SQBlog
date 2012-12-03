using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Application.DTO;
using BDDD.Repository;
using BDDD.ObjectContainer;
using SQBlog.Domain.Repository;
using SQBlog.Domain.Model;
using BDDD.Specification;
using SQBlog.Infrastructure;

namespace SQBlog.Application.Implementation
{
    public class BlogApplication : IBlogApplication
    {
        private readonly IRepositoryContext repositoryContext =
            ServiceLocator.Instance.GetService<IRepositoryContext>();
        private readonly IBlogRepository blogRepository =
            ServiceLocator.Instance.GetService<IBlogRepository>();

        public BlogDTO GetBlog()
        {
            return new BlogDTO
            {
                Title = "title"
            };
        }

        public void ChangePassword(string oldPwd, string newPwd)
        {
            if (string.IsNullOrEmpty(oldPwd))
                throw new ArgumentNullException("旧密码不能为空");
            if (string.IsNullOrEmpty(newPwd))
                throw new ArgumentNullException("新密码不能为空");

            Blog blog = blogRepository.GetAll().FirstOrDefault();
            if (blog == null)
                throw new SQBlogException("不存在Blog信息");

            string encryptedOldPwd = DES.DesEncrypt(oldPwd);
            if (encryptedOldPwd != blog.Password)
                throw new SQBlogException("旧密码不匹配");

            blog.ChangeBlogPassword(encryptedOldPwd);
            blogRepository.Update(blog);
            repositoryContext.Commit();
        }
    }
}
