using AutoMapper;
using Business.Dtos;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CategoryMappingProfiles:Profile
    {
        public CategoryMappingProfiles()
        {
            CreateMap<Category, ListCategoryDto>().ReverseMap();
        }
    }
}
