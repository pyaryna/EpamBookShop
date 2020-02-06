using AutoMapper;
using BookShop.BLL.DTOs;
using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.BLL.MappingProfilers
{
    public class BookCategoryProfile: Profile
    {
        public BookCategoryProfile()
        {
            CreateMap<BookCategory, CategoryDto>()
                .ForMember(i => i.Id, opt => opt.MapFrom(x => x.Category.Id))
                .ForMember(i => i.Name, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
