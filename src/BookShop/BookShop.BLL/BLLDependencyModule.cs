using Autofac;
using BookShop.BLL.Interfaces;
using BookShop.BLL.Services;
using BookShop.DAL;
using BookShop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.BLL
{
    public class BLLDependencyModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<AuthorService>().As<IAuthorService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<NotificationService>().As<INotificationService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<TokenService>().As<ITokenService>();

            builder.RegisterModule<DALDependencyModule>();
        }
    }
}
