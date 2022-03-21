using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.Dtos;
using Business.Requests;
using Business.ValidationRules.FluentValidation;
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

        public void Add(CreateProductRequest createProductRequest)
        {
            ValidationTool.Validate(new CreateProductRequestValidator(), createProductRequest);

            _productBusinessRules.CheckIfProductNameExists(createProductRequest.ProductName);

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
