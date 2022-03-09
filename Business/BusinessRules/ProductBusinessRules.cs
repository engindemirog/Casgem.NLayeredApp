using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class ProductBusinessRules
    {
        IProductDal _productDal;

        public ProductBusinessRules(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void CheckIfProductNameExists(string productName) 
        {
            Product productToCheck = _productDal.Get(p => p.ProductName == productName);

            if (productToCheck != null)
            {
                throw new BusinessException("Bu isimde daha önce ürün eklenmiştir");
            }
        }
    }
}
