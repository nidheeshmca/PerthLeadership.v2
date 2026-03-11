using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class CfoaQuestionV2Configuration : IEntityTypeConfiguration<CfoaQuestionV2>
{
    public void Configure(EntityTypeBuilder<CfoaQuestionV2> builder)
    {
        builder.ToTable("CFOA_Questions_V2");
        builder.HasKey(e => e.Id);
    }
}
