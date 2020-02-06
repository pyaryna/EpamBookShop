using AutoMapper;
using BookShop.BLL.DTOs;
using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.BLL.MappingProfilers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CartDto, Order>()
                 .ForMember(o => o.Id, opt => opt.Ignore());

            CreateMap<AddOrderDto, Order>()
                .ForMember(o => o.Id, opt => opt.Ignore())
                .ForMember(o => o.BookOrders, opt => opt.Ignore());

            CreateMap<Order, OrderDto>()
                .ForMember(o => o.Books, opt => opt.MapFrom(x => x.BookOrders));
        }
    }
}
