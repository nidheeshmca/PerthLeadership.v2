using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Lookup;

namespace PerthLeadership.Infrastructure.Data.Configurations.Lookup;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("tblStates");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.StateName).HasMaxLength(50).IsUnicode(false);
    }
}
