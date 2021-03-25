using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.Mappings
{
    public class BookAuthorLinkMap : IEntityTypeConfiguration<BookAuthorLink>
    {
        #region interface implementations

        public void Configure(EntityTypeBuilder<BookAuthorLink> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Author)
                .WithMany(b => b.BookAuthorLinks)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(a => a.Book)
                .WithMany(b => b.BookAuthorLinks)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }

        #endregion
    }
}
