using Business.Dtos;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        List<ListCategoryDto> GetAll();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
