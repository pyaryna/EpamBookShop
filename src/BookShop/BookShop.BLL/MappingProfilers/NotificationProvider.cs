using AutoMapper;
using BookShop.BLL.DTOs;
using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.BLL.MappingProfilers
{
    public class NotificationProvider: Profile
    {
        public NotificationProvider()
        {
            CreateMap<Notification, NotificationDto>()
                .ReverseMap();

            CreateMap<CallbackDto, Notification>()
                .ForMember(b => b.Id, opt => opt.Ignore());
        }        
    }
}
