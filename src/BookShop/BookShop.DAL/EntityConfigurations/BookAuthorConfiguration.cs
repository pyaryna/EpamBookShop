using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DAL.EntityConfigurations
{
    class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(ba => ba.Id);
        }
    }
}
