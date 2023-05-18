using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.Entity.Mappings
{
    internal class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(k => k.CategoryName).HasColumnName("Name").HasColumnType("nvarchar(70)").IsRequired();
            builder.HasIndex(k => k.CategoryName).IsUnique();
        }
    }
}
