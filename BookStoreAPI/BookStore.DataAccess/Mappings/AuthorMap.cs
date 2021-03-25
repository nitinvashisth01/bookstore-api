using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        #region interface implementations

        public void Configure(EntityTypeBuilder<Author> builder)
        { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }

        #endregion
    }
}
