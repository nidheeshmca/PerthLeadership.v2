using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ImageSettingConfiguration : IEntityTypeConfiguration<ImageSetting>
{
    public void Configure(EntityTypeBuilder<ImageSetting> builder)
    {
        builder.ToTable("ImageSettings");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.RUCategoryId).HasColumnName("RU_CategoryID");
        builder.Property(e => e.VACategoryId).HasColumnName("VA_CategoryID");
        builder.Property(e => e.ImageTop).HasColumnName("imageTop");
        builder.Property(e => e.ImageLeft).HasColumnName("imageLeft");
        builder.Property(e => e.AssessmentType).HasMaxLength(10).IsUnicode(false);
    }
}
