using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        #region interface implementations

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserFullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.AddressLineOne).IsRequired();
            builder.Property(x => x.AddressLineTwo);
            builder.Property(x => x.PinCode).IsRequired();
            builder.Property(x => x.State).IsRequired();
            builder.Property(x => x.Country).IsRequired();

        }

        #endregion
    }
}
