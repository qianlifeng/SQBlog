using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.Application;
using BDDD.Repository;
using SQBlog.Domain.Repository;
using BDDD.ObjectContainer;
using SQBlog.Domain.Model;
using SQBlog.Application;
using SQBlog.Infrastructure;

namespace SQBlog.UnitTest
{
    [TestClass]
    public class BlogApplicationTest
    {
        private IRepositoryContext repositoryContext;
        private IBlogRepository blogRepository;
        private IBlogApplication blogApplicationImpl;

        [ClassInitialize]
        public static void InitApp(TestContext context)
        {
            Common.StartApp();
        }

        [TestInitialize]
        public void EveryTest()
        {
            repositoryContext = ServiceLocator.Instance.GetService<IRepositoryContext>();
            blogRepository = ServiceLocator.Instance.GetService<IBlogRepository>();
            blogApplicationImpl = ServiceLocator.Instance.GetService<IBlogApplication>();
        }

        [TestMethod]
        [Description("修改博客登录密码")]
        public void ChangePassword()
        {
            Blog blog = blogRepository.GetFirstItem();
            Assert.IsNotNull(blog);
            Assert.AreEqual<string>(DES.DesEncrypt("123456"), blog.Password);

            blogApplicationImpl.ChangePassword("123456", "123");

            blog = blogRepository.GetFirstItem();
            Assert.AreEqual<string>(DES.DesEncrypt("123"), blog.Password);

            blogApplicationImpl.ChangePassword("123", "123456");
        }

        [TestMethod]
        [Description("修改博客名称")]
        public void ChangeTitle()
        {
            Blog blog = blogRepository.GetFirstItem();
            Assert.IsNotNull(blog);
            Assert.AreEqual<string>("Scott Qian", blog.Title);

            blogApplicationImpl.ChangeTitle("Qian");

            blog = blogRepository.GetFirstItem();
            Assert.AreEqual<string>("Qian", blog.Title);

            blogApplicationImpl.ChangeTitle("Scott Qian");
        }

        [TestMethod]
        [Description("修改博客副标题")]
        public void ChangeSubTitle()
        {
            Blog blog = blogRepository.GetFirstItem();
            Assert.IsNotNull(blog);
            Assert.AreEqual<string>(string.Empty, blog.SubTitle);

            blogApplicationImpl.ChangeSubTitle("test");
            blog = blogRepository.GetFirstItem();
            Assert.AreEqual<string>("test", blog.SubTitle);

            blogApplicationImpl.ChangeSubTitle(string.Empty);
            blog = blogRepository.GetFirstItem();
            Assert.AreEqual<string>(string.Empty, blog.SubTitle);
        }

        [TestMethod]
        [Description("修改博客主题")]
        public void ChangeTheme()
        {
            Blog blog = blogRepository.GetFirstItem();
            Assert.IsNotNull(blog);
            Assert.AreEqual<string>("Default", blog.Theme);

            blogApplicationImpl.ChangeTheme("test");
            blog = blogRepository.GetFirstItem();
            Assert.AreEqual<string>("test", blog.Theme);

            blogApplicationImpl.ChangeTheme("Default");
        }
    }
}
