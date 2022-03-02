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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<ListProductDto> GetAll()
        {
            //İş kuralları
            return _productDal.GetList();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
