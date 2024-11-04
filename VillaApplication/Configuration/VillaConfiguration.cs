using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VillaApplication.Model.Data;

namespace VillaApplication.Configuration
{
    public class VillaConfiguration : IEntityTypeConfiguration<Villa>
    {
        public void Configure(EntityTypeBuilder<Villa> builder)
        {
            builder.ToTable(nameof(Villa)); 

            builder.HasKey(v => v.Id);
            builder.HasIndex(v => v.OwnerId);

            builder.Property(v => v.Id).ValueGeneratedOnAdd();
            builder.Property(v => v.Name).IsRequired();
            builder.Property(v => v.OwnerId).IsRequired();
            builder.Property(v => v.CreatedDate).IsRequired();
            builder.Property(v => v.EditedDate).IsRequired();

            builder.HasOne(v => v.Owner)
                .WithMany(o => o.villas)
                .HasForeignKey(v => v.OwnerId)
                .HasConstraintName("FK_Villa_Owner");
        }
    }
}
