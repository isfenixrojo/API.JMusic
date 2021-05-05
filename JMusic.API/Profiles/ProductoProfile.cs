using AutoMapper;
using JMusic.DTOs;
using JMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMusic.API.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            this.CreateMap<Producto, ProductoDTO>().ReverseMap();
        }
    }
}
