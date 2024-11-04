using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaApplication.Model.Data;

namespace VillaApplication.Configuration
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable(nameof(Owner));

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.FristName).IsRequired();
            builder.Property(o => o.LastName).IsRequired();
            builder.Property(o => o.CreatedDate).IsRequired();
            builder.Property(o => o.EditedDate).IsRequired();
        }
    }
}
