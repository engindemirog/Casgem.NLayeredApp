using AutoMapper;
using Business.Abstracts;
using Business.Dtos;
using Business.Requests;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    { 
        IProductDal _productDal;
        IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public void Add(CreateProductRequest createProductRequest)
        {
            Product product = _mapper.Map<Product>(createProductRequest);
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<ListProductDto> GetAll()
        {
            //İş kuralları
            var result = _productDal.GetAllWithCategory();
            List<ListProductDto> list = _mapper.Map<List<ListProductDto>>(result);
            return list;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
