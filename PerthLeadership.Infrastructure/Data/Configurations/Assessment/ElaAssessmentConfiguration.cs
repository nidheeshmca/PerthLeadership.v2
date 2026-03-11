using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ElaAssessmentConfiguration : IEntityTypeConfiguration<ElaAssessment>
{
    public void Configure(EntityTypeBuilder<ElaAssessment> builder)
    {
        builder.ToTable("ELA_Assessment");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.UserId).HasColumnName("userid").HasMaxLength(50);
        builder.Property(e => e.StartDate).HasColumnName("startdate").HasColumnType("smalldatetime");
        builder.Property(e => e.CompletionDate).HasColumnName("completiondate").HasColumnType("smalldatetime");
        builder.Property(e => e.ResetDate).HasColumnName("resetdate").HasColumnType("smalldatetime");
        builder.Property(e => e.TestStatus).HasColumnName("teststatus").HasMaxLength(50);
        builder.Property(e => e.Cnt).HasColumnName("cnt");
        builder.Property(e => e.Score1).HasColumnName("score1");
        builder.Property(e => e.Score2).HasColumnName("score2");
        builder.Property(e => e.Score3).HasColumnName("score3");
        builder.Property(e => e.Score4).HasColumnName("score4");
        builder.Property(e => e.Score5).HasColumnName("score5");
        builder.Property(e => e.Score6).HasColumnName("score6");
        builder.Property(e => e.Score7).HasColumnName("score7");
        builder.Property(e => e.Score8).HasColumnName("score8");
        builder.Property(e => e.ModeScore1).HasColumnName("modescore1");
        builder.Property(e => e.ModeScore2).HasColumnName("modescore2");
        builder.Property(e => e.ModeScore3).HasColumnName("modescore3");
        builder.Property(e => e.ModeScore4).HasColumnName("modescore4");
        builder.Property(e => e.DominantMode).HasColumnName("dominantmode");
        builder.Property(e => e.DominantType).HasColumnName("dominanttype");
        builder.Property(e => e.NdType1).HasColumnName("ndtype1");
        builder.Property(e => e.NdType2).HasColumnName("ndtype2");
        builder.Property(e => e.NdType3).HasColumnName("ndtype3");
        builder.Property(e => e.NdType4).HasColumnName("ndtype4");
    }
}
