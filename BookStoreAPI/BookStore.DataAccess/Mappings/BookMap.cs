using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        #region interface implementations

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            
            builder.Property(x => x.Price).IsRequired();
            
            builder.Property(x => x.Quantity).IsRequired();
            
            builder.Property(x => x.IsAvailable);

            builder.HasOne(a => a.BookType)
                .WithMany(b => b.Books)
                .HasForeignKey(c => c.BookTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }

        #endregion
    }
}
