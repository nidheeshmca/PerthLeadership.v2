using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Admin;

namespace PerthLeadership.Infrastructure.Data.Configurations.Admin;

public class MenuUserConfiguration : IEntityTypeConfiguration<MenuUser>
{
    public void Configure(EntityTypeBuilder<MenuUser> builder)
    {
        builder.ToTable("tblMenuUsers");
        builder.HasKey(e => e.Id);
    }
}
