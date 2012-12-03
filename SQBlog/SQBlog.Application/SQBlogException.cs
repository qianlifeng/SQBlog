using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQBlog.Application
{
    public class SQBlogException : Exception
    {
        public SQBlogException() : base() { }
        public SQBlogException(string message) : base(message) { }
        public SQBlogException(string message, Exception innerException) : base(message, innerException) { }
        public SQBlogException(string format, params object[] args) : base(string.Format(format, args)) { }
    }
}