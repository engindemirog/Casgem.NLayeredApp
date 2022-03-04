using AutoMapper;
using Business.Dtos;
using Business.Requests;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ProductMappingProfiles:Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<Product, ListProductDto>()
                .ForMember(p=>p.CategoryName,opt=>opt.MapFrom(p=>p.Category.CategoryName))
                .ReverseMap();

            CreateMap<Product, CreateProductRequest>()
                .ForMember(p => p.CategoryId, opt => opt.MapFrom(p => p.Category.CategoryId))
                .ReverseMap();
        }
    }
}
