using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Elma", UnitsInStock=10, UnitPrice=25, QuantityPerUnit="Kırmızı elma"},
                new Product{ProductId=2, CategoryId=1, ProductName="Armut", UnitsInStock=10, UnitPrice=25, QuantityPerUnit="Sarı armut"},
                new Product{ProductId=3, CategoryId=1, ProductName="Üzüm", UnitsInStock=10, UnitPrice=25, QuantityPerUnit="Siyah üzüm"}
            };
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
