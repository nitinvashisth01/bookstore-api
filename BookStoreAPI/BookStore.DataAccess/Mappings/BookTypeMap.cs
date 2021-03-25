using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.Mappings
{
    public class BookTypeMap : IEntityTypeConfiguration<BookType>
    {
        #region interface implementations

        public void Configure(EntityTypeBuilder<BookType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasData(
                new BookType { Id = 1, Name = "Action and Adventure" },
                new BookType { Id = 2, Name = "Classic" },
                new BookType { Id = 3, Name = "Comic" }
                );
        }

        #endregion
    }
}
