using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQBlog.Application.DTO
{
    public interface IDataTransferObject<T>
    {
        void MapFrom(T domainModel);
        T MapTo();
    }
}
