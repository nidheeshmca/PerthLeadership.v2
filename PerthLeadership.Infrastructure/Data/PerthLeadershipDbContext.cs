using Microsoft.EntityFrameworkCore;
using PerthLeadership.Domain.Entities.Admin;
using PerthLeadership.Domain.Entities.Assessment;
using PerthLeadership.Domain.Entities.Client;
using PerthLeadership.Domain.Entities.Document;
using PerthLeadership.Domain.Entities.Lookup;
using PerthLeadership.Domain.Entities.Reporting;

namespace PerthLeadership.Infrastructure.Data;

public class PerthLeadershipDbContext(DbContextOptions<PerthLeadershipDbContext> options)
    : DbContext(options)
{
    // Client entities
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<OverAllUser> OverAllUsers => Set<OverAllUser>();
    public DbSet<ClientOrganization> ClientOrganizations => Set<ClientOrganization>();
    public DbSet<ClientContact> ClientContacts => Set<ClientContact>();
    public DbSet<TrainingProgram> TrainingPrograms => Set<TrainingProgram>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<AssignProgram> AssignPrograms => Set<AssignProgram>();
    public DbSet<AssignProject> AssignProjects => Set<AssignProject>();
    public DbSet<AssignSubject> AssignSubjects => Set<AssignSubject>();
    public DbSet<CoachingSession> CoachingSessions => Set<CoachingSession>();
    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<AssignCoupon> AssignCoupons => Set<AssignCoupon>();
    public DbSet<Creator> Creators => Set<Creator>();
    public DbSet<Licensee> Licensees => Set<Licensee>();

    // Assessment entities
    public DbSet<FoaAssessment> FoaAssessments => Set<FoaAssessment>();
    public DbSet<FoaQuestion> FoaQuestions => Set<FoaQuestion>();
    public DbSet<FoaQuestionV2> FoaQuestionsV2 => Set<FoaQuestionV2>();
    public DbSet<FoaResult> FoaResults => Set<FoaResult>();
    public DbSet<CfoaAssessment> CfoaAssessments => Set<CfoaAssessment>();
    public DbSet<CfoaQuestion> CfoaQuestions => Set<CfoaQuestion>();
    public DbSet<CfoaQuestionV2> CfoaQuestionsV2 => Set<CfoaQuestionV2>();
    public DbSet<CfoaResult> CfoaResults => Set<CfoaResult>();
    public DbSet<ExoaAssessment> ExoaAssessments => Set<ExoaAssessment>();
    public DbSet<ExoaQuestion> ExoaQuestions => Set<ExoaQuestion>();
    public DbSet<ExoaResult> ExoaResults => Set<ExoaResult>();
    public DbSet<ElaAssessment> ElaAssessments => Set<ElaAssessment>();
    public DbSet<ElaResult> ElaResults => Set<ElaResult>();
    public DbSet<ExoaExplanation> ExoaExplanations => Set<ExoaExplanation>();
    public DbSet<ExoaMode> ExoaModes => Set<ExoaMode>();
    public DbSet<ExoaTrait> ExoaTraits => Set<ExoaTrait>();
    public DbSet<AssessmentSignature> AssessmentSignatures => Set<AssessmentSignature>();
    public DbSet<PercentAssignment> PercentAssignments => Set<PercentAssignment>();
    public DbSet<ImageSetting> ImageSettings => Set<ImageSetting>();
    public DbSet<ExoaFinMission> ExoaFinMissions => Set<ExoaFinMission>();
    public DbSet<ElaExplanation> ElaExplanations => Set<ElaExplanation>();
    public DbSet<ElaMode> ElaModes => Set<ElaMode>();
    public DbSet<ElaTrait> ElaTraits => Set<ElaTrait>();
    public DbSet<AssessmentGroup> AssessmentGroups => Set<AssessmentGroup>();
    public DbSet<AssessmentUserGroup> AssessmentUserGroups => Set<AssessmentUserGroup>();
    public DbSet<ExoaQaAssessment> ExoaQaAssessments => Set<ExoaQaAssessment>();

    // Admin entities
    public DbSet<AdminUser> AdminUsers => Set<AdminUser>();
    public DbSet<AdminLog> AdminLogs => Set<AdminLog>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<MenuUser> MenuUsers => Set<MenuUser>();
    public DbSet<PerthAdminPermission> PerthAdminPermissions => Set<PerthAdminPermission>();

    // Reporting entities
    public DbSet<FoaReport> FoaReports => Set<FoaReport>();
    public DbSet<FmIntensity> FmIntensities => Set<FmIntensity>();
    public DbSet<FmInputScale> FmInputScales => Set<FmInputScale>();
    public DbSet<SubjectAssessmentReport> SubjectAssessmentReports => Set<SubjectAssessmentReport>();

    // Document entities
    public DbSet<AttachedDocument> AttachedDocuments => Set<AttachedDocument>();

    // Lookup entities
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<State> States => Set<State>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<PerthTerm> PerthTerms => Set<PerthTerm>();
    public DbSet<PerthTermTranslation> PerthTermTranslations => Set<PerthTermTranslation>();
    public DbSet<ExamTerm> ExamTerms => Set<ExamTerm>();
    public DbSet<AssessmentDefinition> AssessmentDefinitions => Set<AssessmentDefinition>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PerthLeadershipDbContext).Assembly);
    }
}
