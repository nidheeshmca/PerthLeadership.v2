using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Admin;

namespace PerthLeadership.Infrastructure.Data.Configurations.Admin;

public class AdminUserConfiguration : IEntityTypeConfiguration<AdminUser>
{
    public void Configure(EntityTypeBuilder<AdminUser> builder)
    {
        builder.ToTable("admin");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.Login).HasColumnName("login").HasMaxLength(50);
        builder.Property(e => e.Pass).HasColumnName("pass").HasMaxLength(50);
        builder.Property(e => e.Super).HasColumnName("super");
        builder.Property(e => e.Activation).HasColumnName("Activation");
        builder.Property(e => e.AdminUsers).HasColumnName("AdminUsers");
        builder.Property(e => e.TestUser).HasColumnName("TestUser");
        builder.Property(e => e.NewTest).HasColumnName("newtest");
        builder.Property(e => e.Test).HasColumnName("test");
        builder.Property(e => e.AReport).HasColumnName("Areport");
        builder.Property(e => e.DBReports).HasColumnName("DBReports");
        builder.Property(e => e.FeedBack).HasColumnName("FeedBack");
        builder.Property(e => e.Terms).HasColumnName("Terms");
        builder.Property(e => e.Coupons).HasColumnName("Coupons");
        builder.Property(e => e.AStats).HasColumnName("astats");
        builder.Property(e => e.PayAmt).HasColumnName("payamt");
        builder.Property(e => e.EList).HasColumnName("elist");
        builder.Property(e => e.LastUpdate).HasColumnName("LastUpdate").HasMaxLength(50);
        builder.Property(e => e.Home).HasColumnName("home");
        builder.Property(e => e.PayAmtExoa).HasColumnName("payamtexoa");
        builder.Property(e => e.TestUserExoa).HasColumnName("TestUserexoa");
        builder.Property(e => e.NewTestExoa).HasColumnName("newtestexoa");
        builder.Property(e => e.TestExoa).HasColumnName("testexoa");
        builder.Property(e => e.AReportExoa).HasColumnName("Areportexoa");
        builder.Property(e => e.DBReportsExoa).HasColumnName("DBReportsexoa");
        builder.Property(e => e.FeedBackExoa).HasColumnName("FeedBackexoa");
        builder.Property(e => e.AStatsExoa).HasColumnName("astatsexoa");
        builder.Property(e => e.PayAmtFOA).HasColumnName("PayamtFOA");
        builder.Property(e => e.TestUserFOA).HasColumnName("TestUserFOA");
        builder.Property(e => e.NewTestFOA).HasColumnName("NewTestFOA");
        builder.Property(e => e.TestFOA).HasColumnName("TestFOA");
        builder.Property(e => e.AReportFOA).HasColumnName("AReportFOA");
        builder.Property(e => e.DBReportsFOA).HasColumnName("DBReportsFOA");
        builder.Property(e => e.AStatsFOA).HasColumnName("AStatsFOA");
        builder.Property(e => e.PercentageFOA).HasColumnName("PercentageFOA");
        builder.Property(e => e.FeedBackFOA).HasColumnName("FeedBackFOA");
        builder.Property(e => e.PayAmCFOA).HasColumnName("PayamCFOA");
        builder.Property(e => e.DBReportsCFOA).HasColumnName("DBReportsCFOA");
        builder.Property(e => e.NewTestCFOA).HasColumnName("NewTestCFOA");
        builder.Property(e => e.AStatsCFOA).HasColumnName("AStatsCFOA");
        builder.Property(e => e.TestCFOA).HasColumnName("TestCFOA");
        builder.Property(e => e.AReportCFOA).HasColumnName("AReportCFOA");
        builder.Property(e => e.TestUserCFOA).HasColumnName("TestUserCFOA");
        builder.Property(e => e.FeedBackCFOA).HasColumnName("FeedBackCFOA");
        builder.Property(e => e.PercentageFOA1).HasColumnName("PercentageFOA1");
        builder.Property(e => e.PercentageCFOA).HasColumnName("PercentageCFOA");
        builder.Property(e => e.TestUserSummary).HasColumnName("TestUserSummary");
        builder.Property(e => e.TestMRI).HasColumnName("TestMRI");
    }
}
