using AutoMapper;
using BookShop.BLL.DTOs;
using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.BLL.MappingProfilers
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, CartDto>()
                .ReverseMap();

            CreateMap<AddCartDto, Cart>()
                 .ForMember(b => b.Id, opt => opt.Ignore());
        }
    }
}
