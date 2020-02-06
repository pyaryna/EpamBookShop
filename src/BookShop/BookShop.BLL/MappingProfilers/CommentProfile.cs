using AutoMapper;
using BookShop.BLL.DTOs;
using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.BLL.MappingProfilers
{
    public class CommentProfile: Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ReverseMap();

            CreateMap<AddCommentDto, Comment>()
                .ForMember(b => b.Id, opt => opt.Ignore()); ;
        }        
    }
}
