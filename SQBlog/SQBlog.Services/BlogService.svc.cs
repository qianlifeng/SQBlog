 


using System;
using BDDD;
using BDDD.ObjectContainer;
using System.Collections.Generic;
using SQBlog.Application;
using SQBlog.Application.DTO;

namespace SQBlog.Services
{
	public class BlogService : IBlogApplication
	{
		private readonly IBlogApplication blogApplicationImpl = ServiceLocator.Instance.GetService<IBlogApplication>();
				
		public BlogDTO GetBlog()
		{
			try
			{
				return  blogApplicationImpl.GetBlog();
			}
			catch(Exception ex)
			{
				throw ApplicationFaultDetail.Create(ex);
			}
		}
		
		public void ChangePassword(String oldPwd, String newPwd)
		{
			try
			{
				 blogApplicationImpl.ChangePassword(oldPwd, newPwd);
			}
			catch(Exception ex)
			{
				throw ApplicationFaultDetail.Create(ex);
			}
		}
	}
}
