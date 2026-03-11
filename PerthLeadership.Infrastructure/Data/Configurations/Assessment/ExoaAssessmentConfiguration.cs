using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ExoaAssessmentConfiguration : IEntityTypeConfiguration<ExoaAssessment>
{
    public void Configure(EntityTypeBuilder<ExoaAssessment> builder)
    {
        builder.ToTable("Exoa_Assessment");

        builder.HasKey(e => e.Id)
            .HasName("PK_Exoa_Assessment");

        builder.Property(e => e.UserId).HasColumnName("userid").HasMaxLength(50);
        builder.Property(e => e.StartDate).HasColumnName("startdate").HasColumnType("smalldatetime");
        builder.Property(e => e.CompletionDate).HasColumnName("completiondate").HasColumnType("smalldatetime");
        builder.Property(e => e.ResetDate).HasColumnName("resetdate").HasColumnType("smalldatetime");
        builder.Property(e => e.TestStatus).HasColumnName("teststatus").HasMaxLength(50);
        builder.Property(e => e.Cnt).HasColumnName("cnt");

        // Original scores mapped to oscore columns
        builder.Property(e => e.OriginalScore1).HasColumnName("oscore1");
        builder.Property(e => e.OriginalScore2).HasColumnName("oscore2");
        builder.Property(e => e.OriginalScore3).HasColumnName("oscore3");
        builder.Property(e => e.OriginalScore4).HasColumnName("oscore4");
        builder.Property(e => e.OriginalScore5).HasColumnName("oscore5");
        builder.Property(e => e.OriginalScore6).HasColumnName("oscore6");
        builder.Property(e => e.OriginalScore7).HasColumnName("oscore7");
        builder.Property(e => e.OriginalScore8).HasColumnName("oscore8");

        // Original mode scores mapped to omodescore columns
        builder.Property(e => e.OriginalModeScore1).HasColumnName("omodescore1");
        builder.Property(e => e.OriginalModeScore2).HasColumnName("omodescore2");
        builder.Property(e => e.OriginalModeScore3).HasColumnName("omodescore3");
        builder.Property(e => e.OriginalModeScore4).HasColumnName("omodescore4");

        builder.Property(e => e.Calibration).HasColumnName("calibration").HasMaxLength(50).IsUnicode(false);
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
        builder.Property(e => e.DominantMode2).HasColumnName("dominantmode2");
        builder.Property(e => e.DominantType2).HasColumnName("dominanttype2");
        builder.Property(e => e.CompanyName).HasMaxLength(50);
        builder.Property(e => e.FinMission).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FMDate).HasColumnName("FMdate");
        builder.Property(e => e.FMIntensityImage).HasMaxLength(100).IsUnicode(false);
    }
}
