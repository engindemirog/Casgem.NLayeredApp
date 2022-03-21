﻿using Core.DataAccess;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<Product> GetAllWithCategory();
        Product GetProductWithCategoryById(int id);
        List<Product> GetAllWithCategoryByCategoryId(int categoryId);
    }
}
