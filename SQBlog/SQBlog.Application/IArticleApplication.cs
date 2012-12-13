using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using SQBlog.Application.DTO;

namespace SQBlog.Application
{
    [ServiceContract]
    public interface IArticleApplication
    {
        /// <summary>
        /// 获得文章列表
        /// </summary>
        /// <param name="pageIndex">页序号</param>
        /// <param name="pageSize">每页记录数目</param>
        /// <returns>文章列表</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationFaultDetail))]
        IList<ArticleDTO> GetArtcile(int pageIndex, int pageSize);

        /// <summary>
        /// 创建一篇新的文章
        /// </summary>
        [OperationContract]
        [FaultContract(typeof(ApplicationFaultDetail))]
        void CreateArticle(ArticleDTO articleDTO);
    }
}
