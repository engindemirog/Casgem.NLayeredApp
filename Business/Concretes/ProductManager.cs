using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Business.Dtos;
using Business.Requests;
using Business.ValidationRules.FluentValidation;
using Castle.DynamicProxy;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Validation;
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
        ProductBusinessRules _productBusinessRules;

        public ProductManager(IProductDal productDal, IMapper mapper, ProductBusinessRules productBusinessRules)
        {
            _productDal = productDal;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        [ValidationAspect(typeof(CreateProductRequestValidator))]
        [TransactionScopeAspect()]
        public void Add(CreateProductRequest createProductRequest)
        {
            _productBusinessRules.CheckIfProductNameExists(createProductRequest.ProductName);

            Product product = _mapper.Map<Product>(createProductRequest);
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        [CacheAspect(Priority = 2)]
        //[SecuredOperation("product.read,admin,editor", Priority = 1)]
        //[Operation2("product.getAll")]
       
        public List<ListProductDto> GetAll()
        {
            Thread.Sleep(5000);
            //İş kuralları
            var result = _productDal.GetAllWithCategory();
            List<ListProductDto> list = _mapper.Map<List<ListProductDto>>(result);
            return list;
        }

        [SecuredOperation("product.read,admin,editor")]
        [LogAspect(typeof(FileLogger))]
        public List<ListProductDto> GetAllByCategory(int categoryId)
        {
            var result = _productDal.GetAllWithCategoryByCategoryId(categoryId);
            List<ListProductDto> list = _mapper.Map<List<ListProductDto>>(result);
            return list;
        }

        public GetProductDto GetById(int id)
        {
            var result = _productDal.GetProductWithCategoryById(id);
            GetProductDto response = _mapper.Map<GetProductDto>(result);
            return response;
        }

        public void Update(UpdateProductRequest updateProductRequest)
        {
            Product product = _mapper.Map<Product>(updateProductRequest);
            _productDal.Update(product);
        }
    }
}



