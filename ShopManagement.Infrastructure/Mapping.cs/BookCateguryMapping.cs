using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.BookCateguryAgg;

namespace ShopManagement.Infrastructure.Mapping.cs
{
    public class BookCateguryMapping : IEntityTypeConfiguration<BookCategury>
    {
        public void Configure(EntityTypeBuilder<BookCategury> builder)
        {
            builder.ToTable("BookCateguries");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.KeyWords).HasMaxLength(80).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property( x => x.Slug).HasMaxLength(300).IsRequired();
           
            builder.HasMany(x=>x.Books).WithOne(x => x.Categury).HasForeignKey(x => x.CateguryId);
        }
    }
}
