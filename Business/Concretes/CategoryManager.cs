using AutoMapper;
using Business.Abstracts;
using Business.Dtos;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public List<ListCategoryDto> GetAll()
        {
            var result = _categoryDal.GetList();
            List<ListCategoryDto> list = _mapper.Map<List<ListCategoryDto>>(result);
            return list;
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
