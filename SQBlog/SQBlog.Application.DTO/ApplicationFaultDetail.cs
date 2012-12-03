using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SQBlog.Application.DTO
{
    [Serializable]
    [DataContract]
    public class ApplicationFaultDetail
    {
        [DataMember(Order = 0)]
        public string Message { get; set; }
        [DataMember(Order = 1)]
        public string StackTrace { get; set; }
        [DataMember(Order = 2)]
        public string InnerExceptionDetail { get; set; }

        public static FaultException<ApplicationFaultDetail> Create(Exception ex)
        {
            return new FaultException<ApplicationFaultDetail>(new ApplicationFaultDetail
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    InnerExceptionDetail = ex.InnerException != null ? ex.InnerException.ToString() : null
                }, ex.Message);
        }
    }
}
