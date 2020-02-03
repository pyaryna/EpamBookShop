using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PublishingHouse.BLL;
using PublishingHouse.BLL.MappingProfilers;
using PublishingHouse.DAL;
using PublishingHouse.DAL.Entities;

namespace BookShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        readonly string CorsPolicy = "CorsPolicy";
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PublishingHouseContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("PublishingHouseDb")));

            services.AddIdentity<Customer, IdentityRole>()
                .AddEntityFrameworkStores<PublishingHouseContext>();

            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = Configuration["Authentication:Google:ClientId"];
            //        options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //    })
            //    .AddFacebook(options =>
            //    {
            //        options.ClientId = Configuration["Authentication:Facebook:AppId"];
            //        options.ClientSecret = Configuration["Authentication:Facebook:AppSecret"];
            //    });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookShop", Version = "v1" });
            });

            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                });
            });

            services.AddAutoMapper(typeof(AuthorProfile).Assembly);
            services.AddAutoMapper(typeof(BookProfile).Assembly);
            services.AddAutoMapper(typeof(BookCategoryProfile).Assembly);
            services.AddAutoMapper(typeof(BookOrderProfile).Assembly);
            services.AddAutoMapper(typeof(BookProfile).Assembly);
            services.AddAutoMapper(typeof(CartProfile).Assembly);
            services.AddAutoMapper(typeof(CommentProfile).Assembly);
            services.AddAutoMapper(typeof(NotificationProvider).Assembly);
            services.AddAutoMapper(typeof(OrderProfile).Assembly);

            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterModule<BLLDependencyModule>();

            AutofacContainer = builder.Build();

            return new AutofacServiceProvider(AutofacContainer);
            //
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookShop V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
            //app.UseCors("Default");
            app.UseCors(CorsPolicy);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
