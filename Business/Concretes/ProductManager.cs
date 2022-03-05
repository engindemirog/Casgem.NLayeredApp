using AutoMapper;
using Business.Abstracts;
using Business.Dtos;
using Business.Requests;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstracts;
using Entities.Concretes;
using FluentValidation;
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
            CreateProductRequestValidator validator = new CreateProductRequestValidator();
            var result = validator.Validate(createProductRequest);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


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

        public void Update(UpdateProductRequest updateProductRequest)
        {
            Product product = _mapper.Map<Product>(updateProductRequest);
            _productDal.Update(product);
        }
    }
}

//