using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DAL.EntityConfigurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Name)
                .IsRequired();

            builder.Property(n => n.Email)
                .IsRequired();

            builder.Property(n => n.Subject)
                .IsRequired();

            builder.Property(n => n.Text)
                .IsRequired();
        }
    }
}
