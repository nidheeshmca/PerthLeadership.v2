using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("tblSubjects");

        builder.HasKey(e => e.Id);
        builder.HasAlternateKey(e => e.SubjectId).HasName("AK_tblSubjects_SubjectId");

        builder.Property(e => e.SubjectId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.Salutation).HasMaxLength(5).IsUnicode(false);
        builder.Property(e => e.FirstName).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.LastName).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Email).HasMaxLength(200).IsUnicode(false);
        builder.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.AsstBeginDate).HasColumnType("smalldatetime");
        builder.Property(e => e.AsstEndDate).HasColumnType("smalldatetime");
        builder.Property(e => e.Address1).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Address2).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.City).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.State).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Zip).HasMaxLength(15).IsUnicode(false);
        builder.Property(e => e.Country).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Website).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Phone1).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Phone2).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Dept).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Designation).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.PositionLevel).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Gender).HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.Age).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.Education).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.AreaEndeavor).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Experience).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Industry).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.SizeRevenue).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.OrganizationSize).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FinancialMission).HasColumnName("Financialmission").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FMIntensityImage).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Organization).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.UserType).HasMaxLength(50).IsUnicode(false);

        builder.HasOne(e => e.OverAllUser)
            .WithMany(u => u.Subjects)
            .HasForeignKey(e => e.OverallUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ClientOrganization)
            .WithMany(c => c.Subjects)
            .HasForeignKey(e => e.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
