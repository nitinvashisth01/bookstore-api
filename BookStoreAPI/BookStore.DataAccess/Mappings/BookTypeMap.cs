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
        }

        #endregion
    }
}
