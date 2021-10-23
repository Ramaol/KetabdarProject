using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.BookAgg;

namespace ShopManagement.Infrastructure.Mapping.cs
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey( x=> x.Id);
            builder.Property( x=>x.Name).HasMaxLength(255).IsRequired();
            builder.Property( x=>x.ISBN).HasMaxLength(30).IsRequired();        
            builder.Property( x=>x.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property( x=>x.Description).HasMaxLength(5000).IsRequired();
            builder.Property( x=>x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property( x=>x.PictureAlt).HasMaxLength(255).IsRequired();        
            builder.Property( x=>x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property( x=>x.Keywords).HasMaxLength(100).IsRequired();
            builder.Property( x=>x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property( x=>x.Writer).HasMaxLength(500).IsRequired();        
            builder.Property( x=>x.Weight).HasMaxLength(100);
            builder.Property( x=>x.BookCut).HasMaxLength(50).IsRequired();
            builder.Property( x=>x.CoverKind).HasMaxLength(50).IsRequired();
            builder.Property( x=>x.PublisherName).HasMaxLength(500).IsRequired();        
            builder.Property( x=>x.PageCount).HasMaxLength(100);
            builder.Property( x=>x.UnitPrice).HasMaxLength(255);
            builder.Property( x=>x.PublishDate).HasMaxLength(500);

            builder.HasOne(x => x.Categury).WithMany(x => x.Books).HasForeignKey(x=>x.CateguryId);
            

        }
    }
}
