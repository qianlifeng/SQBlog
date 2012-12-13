using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQBlog.Domain.Model;
using System.Runtime.Serialization;
using SQBlog.Domain.Repository;
using BDDD.ObjectContainer;

namespace SQBlog.Application.DTO
{
    [DataContract]
    public class CategoryDTO : IDataTransferObject<Category>
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

        public void MapFrom(Category domainModel)
        {
            Name = domainModel.Name;
            Description = domainModel.Description;
        }

        public Category MapTo()
        {
            ICategoryRepository blogRepository = ServiceLocator.Instance.GetService<ICategoryRepository>();
            Category existedCategory = blogRepository.GetCategory(Name);
            if (existedCategory == null)
            {
                return new Category(Name, Description);;
            }
            else
            {
                existedCategory.ChangeName(Name);
                existedCategory.ChangeDescription(Description);
                return existedCategory;
            }
        }
    }
}
