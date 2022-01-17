using AutoMapper;
using ProductWebApi.Data.Entities;
using ProductWebApi.DTOs.CategoryDTOs;
using ProductWebApi.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApi
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ProductPostDto, Product>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<List<Product>, ProductListDto>();
            CreateMap<Product, ProductListDto>();
            CreateMap<List<Category>, CategoryListDto>();
        }
    }
}
