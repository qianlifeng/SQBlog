using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Application.DTO;
using BDDD.ObjectContainer;
using BDDD.Repository;
using SQBlog.Domain.Repository;
using SQBlog.Domain.Model;

namespace SQBlog.Application.Implementation
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IRepositoryContext repositoryContext =
            ServiceLocator.Instance.GetService<IRepositoryContext>();
        private readonly IArticleRepository articleRepository =
            ServiceLocator.Instance.GetService<IArticleRepository>();

        public IList<ArticleDTO> GetArtcile(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0) throw new ArgumentException("页序号必须大于0");
            if (pageSize <= 0) throw new ArgumentException("每页数量必须大于0");
            

            IEnumerable<Article> articles = articleRepository.GetAll(pageIndex, pageSize, o => o.PublishDate, SortOrder.Descending);
            return (from p in articles select new ArticleDTO(p)).ToList();
        }


        public void CreateArticle(ArticleDTO articleDTO)
        {
            if (string.IsNullOrEmpty(articleDTO.Title)) throw new ArgumentException("标题不能为空");
            if (string.IsNullOrEmpty(articleDTO.Category)) throw new ArgumentException("类别不能为空");
            if (articleDTO.Id != Guid.Empty) throw new ArgumentException("新文章不应该包含ID信息");


            articleRepository.Add(articleDTO.MapTo());
            repositoryContext.Commit();
        }
    }
}
