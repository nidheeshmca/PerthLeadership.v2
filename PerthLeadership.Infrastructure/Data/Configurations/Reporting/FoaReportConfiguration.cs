using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Reporting;

namespace PerthLeadership.Infrastructure.Data.Configurations.Reporting;

public class FoaReportConfiguration : IEntityTypeConfiguration<FoaReport>
{
    public void Configure(EntityTypeBuilder<FoaReport> builder)
    {
        builder.ToTable("FOA_Report");

        builder.HasKey(e => e.SignatureId);

        builder.Property(e => e.SignatureId)
            .ValueGeneratedNever();

        builder.Property(e => e.ExecutiveSummary1).HasColumnName("ExecutiveSummary_1").HasColumnType("nvarchar(max)");
        builder.Property(e => e.ExecutiveSummary2).HasColumnName("ExecutiveSummary_2").HasColumnType("nvarchar(max)");
        builder.Property(e => e.ExecutiveSummary3).HasColumnName("ExecutiveSummary_3").HasColumnType("nvarchar(max)");
        builder.Property(e => e.SignatureImage).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FinancialMission1).HasColumnName("FinancialMission_1").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FinancialMission2).HasColumnName("FinancialMission_2").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FinancialMission3).HasColumnName("FinancialMission_3").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FinancialMission4).HasColumnName("FinancialMission_4").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FinancialMission5).HasColumnName("FinancialMission_5").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FinancialMission6).HasColumnName("FinancialMission_6").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FinancialMission7).HasColumnName("FinancialMission_7").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FinancialMission8).HasColumnName("FinancialMission_8").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FinancialMission9).HasColumnName("FinancialMission_9").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FinancialMission10).HasColumnName("FinancialMission_10").HasColumnType("nvarchar(max)");
        builder.Property(e => e.ValuationTrajectoryImage).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FutureValuation1).HasColumnName("FutureValuation_1").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FutureValuation2).HasColumnName("FutureValuation_2").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FutureValuation3).HasColumnName("FutureValuation_3").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FutureValuation4).HasColumnName("FutureValuation_4").HasColumnType("nvarchar(max)");
        builder.Property(e => e.FutureValuation5).HasColumnName("FutureValuation_5").HasColumnType("nvarchar(max)");
        builder.Property(e => e.TrajectoryExplaination1).HasColumnName("TrajectoryExplaination_1").HasColumnType("nvarchar(max)");
        builder.Property(e => e.TrajectoryExplaination2).HasColumnName("TrajectoryExplaination_2").HasColumnType("nvarchar(max)");
        builder.Property(e => e.TrajectoryExplaination3).HasColumnName("TrajectoryExplaination_3").HasColumnType("nvarchar(max)");
        builder.Property(e => e.TrajectoryExplaination4).HasColumnName("TrajectoryExplaination_4").HasColumnType("nvarchar(max)");
        builder.Property(e => e.TrajectoryExplaination5).HasColumnName("TrajectoryExplaination_5").HasColumnType("nvarchar(max)");
        builder.Property(e => e.Summary).HasColumnType("nvarchar(max)");
    }
}
