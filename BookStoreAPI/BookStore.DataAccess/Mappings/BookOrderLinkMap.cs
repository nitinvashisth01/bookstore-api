using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.Mappings
{
    public class BookOrderLinkMap : IEntityTypeConfiguration<BookOrderLink>
    {
        #region interface implementations

        public void Configure(EntityTypeBuilder<BookOrderLink> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Order)
                .WithMany(b => b.BookOrderLinks)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.Book)
                .WithMany(b => b.BookOrderLinks)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }

        #endregion
    }
}
