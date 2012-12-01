using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Application.DTO;

namespace SQBlog.Application
{
    public interface IBlogApplication
    {
        BlogDTO GetBlog();
    }
}
