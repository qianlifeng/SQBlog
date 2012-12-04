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

            Blog blog = blogRepository.GetFirstItem();
            if (blog == null)
                throw new SQBlogException("不存在Blog信息");

            if (DES.DesEncrypt(oldPwd) != blog.Password)
                throw new SQBlogException("旧密码不匹配");

            blog.ChangeBlogPassword(DES.DesEncrypt(newPwd));
            blogRepository.Update(blog);
            repositoryContext.Commit();
        }

        public void ChangeTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("博客标题不能为空");
            Blog blog = blogRepository.GetFirstItem();
            if (blog == null)
                throw new SQBlogException("不存在Blog信息");

            blog.SetBlogTitle(title);
            blogRepository.Update(blog);
            repositoryContext.Commit();
        }

        public void ChangeSubTitle(string subTitle)
        {
            Blog blog = blogRepository.GetFirstItem();
            if (blog == null)
                throw new SQBlogException("不存在Blog信息");

            blog.SetBlogSubTitle(subTitle);
            blogRepository.Update(blog);
            repositoryContext.Commit();
        }

        public void ChangeTheme(string theme)
        {
            if (string.IsNullOrEmpty(theme))
                throw new ArgumentNullException("主题名字不能为空");
            Blog blog = blogRepository.GetFirstItem();
            if (blog == null)
                throw new SQBlogException("不存在Blog信息");

            blog.SetBlogTheme(theme);
            blogRepository.Update(blog);
            repositoryContext.Commit();
        }
    }
}
