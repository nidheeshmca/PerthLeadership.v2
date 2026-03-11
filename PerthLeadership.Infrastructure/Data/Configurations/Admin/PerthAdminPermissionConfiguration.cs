using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Admin;

namespace PerthLeadership.Infrastructure.Data.Configurations.Admin;

public class PerthAdminPermissionConfiguration : IEntityTypeConfiguration<PerthAdminPermission>
{
    public void Configure(EntityTypeBuilder<PerthAdminPermission> builder)
    {
        builder.ToTable("tblPerthAdminPermissions");
        builder.HasKey(e => e.Id);
    }
}
