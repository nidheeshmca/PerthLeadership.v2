using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class FoaQuestionV2Configuration : IEntityTypeConfiguration<FoaQuestionV2>
{
    public void Configure(EntityTypeBuilder<FoaQuestionV2> builder)
    {
        builder.ToTable("FOA_Questions_V2");
        builder.HasKey(e => e.Id);
    }
}
