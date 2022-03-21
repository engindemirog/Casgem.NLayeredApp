using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<Product> GetAllWithCategory()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Products.Include(p=>p.Category).ToList();
            }
        }

        public List<Product> GetAllWithCategoryByCategoryId(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.Include(p => p.Category).Where(p=>p.Category.CategoryId==categoryId).ToList();
            }
        }

        public Product GetProductWithCategoryById(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.Include(p => p.Category).SingleOrDefault(p=>p.ProductId==id);
            }
        }
    }
}
