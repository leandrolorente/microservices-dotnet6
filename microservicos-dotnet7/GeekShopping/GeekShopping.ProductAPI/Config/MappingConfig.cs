﻿using AutoMapper;
using GeekShopping.ProductAPI.Data.DTO;
using GeekShopping.ProductAPI.Migrations;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        { 
           var mappingConfig = new MapperConfiguration(config =>
           {
               config.CreateMap<ProductDto, Product>();
               config.CreateMap<Product, ProductDto>();
           });
            return mappingConfig;  
        }
    }
}
