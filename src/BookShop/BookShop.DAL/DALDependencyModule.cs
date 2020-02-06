﻿using Autofac;
using BookShop.DAL.Interfaces.Repositories;
using BookShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DAL
{
    public class DALDependencyModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {                  
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();
            builder.RegisterType<NotificationRepository>().As<INotificationRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<PublishingHouseUnitOfWork>().As<IPublishingHouseUnitOfWork>();
        }
    }
}
