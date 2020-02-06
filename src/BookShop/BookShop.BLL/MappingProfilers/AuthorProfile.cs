using AutoMapper;
using BookShop.BLL.DTOs;
using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.BLL.MappingProfilers
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ReverseMap();

            CreateMap<AddAuthorDto, Author>();
        }        
    }
}
