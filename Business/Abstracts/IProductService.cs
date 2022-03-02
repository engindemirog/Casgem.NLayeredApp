using Business.Dtos;
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
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
