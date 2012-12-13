using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.Repository;
using SQBlog.Domain.Repository;
using SQBlog.Application;
using BDDD.ObjectContainer;
using SQBlog.Application.DTO;

namespace SQBlog.UnitTest
{
    [TestClass]
    public class ArticleApplicationTest
    {
        private IRepositoryContext repositoryContext;
        private IArticleRepository articleRepository;
        private IArticleApplication articleApplicationImpl;

        [ClassInitialize]
        public static void InitApp(TestContext context)
        {
            Common.StartApp();
        }

        [TestInitialize]
        public void EveryTest()
        {
            repositoryContext = ServiceLocator.Instance.GetService<IRepositoryContext>();
            articleRepository = ServiceLocator.Instance.GetService<IArticleRepository>();
            articleApplicationImpl = ServiceLocator.Instance.GetService<IArticleApplication>();
        }

        public void Article_CreateArticle()
        {
            string title = "title";
            string content = "<h1>content</h1>";
            string contentBio = "this is content";
            string category = "C#";
            List<string> tags = new List<string> { "dotnet", "python" };
            ArticleDTO dto = new ArticleDTO()
            {
                Title = title,
                Content = content,
                ContentBio = contentBio,
                Category = category,
                Tags = tags
            };
            articleApplicationImpl.CreateArticle(dto);
        }

        [TestMethod]
        public void Article_GetArtcileByPage()
        {
            IList<ArticleDTO> articles = articleApplicationImpl.GetArtcile(1, 10);

            Assert.AreEqual<int>(articles.Count, 0);
        }
    }
}
