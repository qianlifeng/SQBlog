using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Application.DTO;
using System.ServiceModel;

namespace SQBlog.Application
{
    [ServiceContract]
    public interface IBlogApplication
    {
        /// <summary>
        /// 获得博客信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationFaultDetail))]
        BlogDTO GetBlog();

        /// <summary>
        /// 重置博客密码
        /// </summary>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns>是否修改成功</returns>
        [OperationContract]
        [FaultContract(typeof(ApplicationFaultDetail))]
        void ChangePassword(string oldPwd, string newPwd);
    }
}
