using Business.Dtos;
using Business.Requests;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductService
    {
        List<ListProductDto> GetAll();
        GetProductDto GetById(int id);
        void Add(CreateProductRequest createProductRequest);
        void Update(UpdateProductRequest updateProductRequest);
        void Delete(Product product);
    }
}

//Brand,Color,Car
//Bu üç nesne için response & request desenini uygulayınız.