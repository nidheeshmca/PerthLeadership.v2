using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerthLeadership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    super = table.Column<bool>(type: "bit", nullable: true),
                    Activation = table.Column<bool>(type: "bit", nullable: true),
                    AdminUsers = table.Column<bool>(type: "bit", nullable: true),
                    TestUser = table.Column<bool>(type: "bit", nullable: true),
                    newtest = table.Column<bool>(type: "bit", nullable: true),
                    test = table.Column<bool>(type: "bit", nullable: true),
                    Areport = table.Column<bool>(type: "bit", nullable: true),
                    DBReports = table.Column<bool>(type: "bit", nullable: true),
                    FeedBack = table.Column<bool>(type: "bit", nullable: true),
                    Terms = table.Column<bool>(type: "bit", nullable: true),
                    Coupons = table.Column<bool>(type: "bit", nullable: true),
                    astats = table.Column<bool>(type: "bit", nullable: true),
                    payamt = table.Column<bool>(type: "bit", nullable: true),
                    elist = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    home = table.Column<bool>(type: "bit", nullable: true),
                    payamtexoa = table.Column<bool>(type: "bit", nullable: true),
                    TestUserexoa = table.Column<bool>(type: "bit", nullable: true),
                    newtestexoa = table.Column<bool>(type: "bit", nullable: true),
                    testexoa = table.Column<bool>(type: "bit", nullable: true),
                    Areportexoa = table.Column<bool>(type: "bit", nullable: true),
                    DBReportsexoa = table.Column<bool>(type: "bit", nullable: true),
                    FeedBackexoa = table.Column<bool>(type: "bit", nullable: true),
                    astatsexoa = table.Column<bool>(type: "bit", nullable: true),
                    PayamtFOA = table.Column<bool>(type: "bit", nullable: true),
                    TestUserFOA = table.Column<bool>(type: "bit", nullable: true),
                    NewTestFOA = table.Column<bool>(type: "bit", nullable: true),
                    TestFOA = table.Column<bool>(type: "bit", nullable: true),
                    AReportFOA = table.Column<bool>(type: "bit", nullable: true),
                    DBReportsFOA = table.Column<bool>(type: "bit", nullable: true),
                    AStatsFOA = table.Column<bool>(type: "bit", nullable: true),
                    PercentageFOA = table.Column<bool>(type: "bit", nullable: true),
                    FeedBackFOA = table.Column<bool>(type: "bit", nullable: true),
                    PayamCFOA = table.Column<bool>(type: "bit", nullable: true),
                    DBReportsCFOA = table.Column<bool>(type: "bit", nullable: true),
                    NewTestCFOA = table.Column<bool>(type: "bit", nullable: true),
                    AStatsCFOA = table.Column<bool>(type: "bit", nullable: true),
                    TestCFOA = table.Column<bool>(type: "bit", nullable: true),
                    AReportCFOA = table.Column<bool>(type: "bit", nullable: true),
                    TestUserCFOA = table.Column<bool>(type: "bit", nullable: true),
                    FeedBackCFOA = table.Column<bool>(type: "bit", nullable: true),
                    PercentageFOA1 = table.Column<bool>(type: "bit", nullable: true),
                    PercentageCFOA = table.Column<bool>(type: "bit", nullable: true),
                    TestUserSummary = table.Column<bool>(type: "bit", nullable: true),
                    TestMRI = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Admin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Groupid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AVGRU = table.Column<int>(type: "int", nullable: true),
                    AVGVA = table.Column<int>(type: "int", nullable: true),
                    AVGPAST = table.Column<int>(type: "int", nullable: true),
                    AVGNOW = table.Column<int>(type: "int", nullable: true),
                    AVGFUTURE = table.Column<int>(type: "int", nullable: true),
                    REFRU = table.Column<int>(type: "int", nullable: true),
                    REFVA = table.Column<int>(type: "int", nullable: true),
                    GroupStatus = table.Column<bool>(type: "bit", nullable: true),
                    AssessmentType = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentGroups", x => x.Id);
                    table.UniqueConstraint("AK_AssessmentGroups_GroupId", x => x.Groupid);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentSignatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VACategoryId = table.Column<byte>(type: "tinyint", nullable: true),
                    RUCategoryId = table.Column<byte>(type: "tinyint", nullable: true),
                    SignatureId = table.Column<int>(type: "int", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ValuationOutcome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MissionImage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GraphImage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AssessmentType = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentSignatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CFOA_Assessment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PID = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    SumVA = table.Column<int>(type: "int", nullable: true),
                    SumRU = table.Column<int>(type: "int", nullable: true),
                    Past = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Now = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Future = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Companyname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cnt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFOA_Assessment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cFOA_Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    QB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QF = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<string>(type: "char(1)", nullable: true),
                    IsGenuine = table.Column<bool>(type: "bit", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    A = table.Column<short>(type: "smallint", nullable: true),
                    B = table.Column<short>(type: "smallint", nullable: true),
                    C = table.Column<short>(type: "smallint", nullable: true),
                    D = table.Column<short>(type: "smallint", nullable: true),
                    E = table.Column<short>(type: "smallint", nullable: true),
                    F = table.Column<short>(type: "smallint", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFOA_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CFOA_Questions_V2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGenuine = table.Column<bool>(type: "bit", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    A = table.Column<short>(type: "smallint", nullable: true),
                    B = table.Column<short>(type: "smallint", nullable: true),
                    C = table.Column<short>(type: "smallint", nullable: true),
                    D = table.Column<short>(type: "smallint", nullable: true),
                    E = table.Column<short>(type: "smallint", nullable: true),
                    F = table.Column<short>(type: "smallint", nullable: true),
                    QuestionIdRef = table.Column<int>(type: "int", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFOA_Questions_V2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CFOA_Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PID = table.Column<long>(type: "bigint", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Question = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    EnterDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnsTextLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnsTextRight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFOA_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RegionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ELA_Assessment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PID = table.Column<long>(type: "bigint", nullable: true),
                    userid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    startdate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    completiondate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    resetdate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    teststatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cnt = table.Column<int>(type: "int", nullable: true),
                    score1 = table.Column<int>(type: "int", nullable: true),
                    score2 = table.Column<int>(type: "int", nullable: true),
                    score3 = table.Column<int>(type: "int", nullable: true),
                    score4 = table.Column<int>(type: "int", nullable: true),
                    score5 = table.Column<int>(type: "int", nullable: true),
                    score6 = table.Column<int>(type: "int", nullable: true),
                    score7 = table.Column<int>(type: "int", nullable: true),
                    score8 = table.Column<int>(type: "int", nullable: true),
                    modescore1 = table.Column<int>(type: "int", nullable: true),
                    modescore2 = table.Column<int>(type: "int", nullable: true),
                    modescore3 = table.Column<int>(type: "int", nullable: true),
                    modescore4 = table.Column<int>(type: "int", nullable: true),
                    dominantmode = table.Column<int>(type: "int", nullable: true),
                    dominanttype = table.Column<int>(type: "int", nullable: true),
                    ndtype1 = table.Column<int>(type: "int", nullable: true),
                    ndtype2 = table.Column<int>(type: "int", nullable: true),
                    ndtype3 = table.Column<int>(type: "int", nullable: true),
                    ndtype4 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ELA_Assessment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ELA_Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PID = table.Column<long>(type: "bigint", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Question = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    EnterDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnsTextLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnsTextRight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ELA_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exam_Terms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Exam = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Culture = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Terms = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam_Terms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exoa_Assessment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PID = table.Column<long>(type: "bigint", nullable: true),
                    userid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    startdate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    completiondate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    resetdate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    teststatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cnt = table.Column<int>(type: "int", nullable: true),
                    oscore1 = table.Column<int>(type: "int", nullable: true),
                    oscore2 = table.Column<int>(type: "int", nullable: true),
                    oscore3 = table.Column<int>(type: "int", nullable: true),
                    oscore4 = table.Column<int>(type: "int", nullable: true),
                    oscore5 = table.Column<int>(type: "int", nullable: true),
                    oscore6 = table.Column<int>(type: "int", nullable: true),
                    oscore7 = table.Column<int>(type: "int", nullable: true),
                    oscore8 = table.Column<int>(type: "int", nullable: true),
                    omodescore1 = table.Column<int>(type: "int", nullable: true),
                    omodescore2 = table.Column<int>(type: "int", nullable: true),
                    omodescore3 = table.Column<int>(type: "int", nullable: true),
                    omodescore4 = table.Column<int>(type: "int", nullable: true),
                    calibration = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    score1 = table.Column<int>(type: "int", nullable: true),
                    score2 = table.Column<int>(type: "int", nullable: true),
                    score3 = table.Column<int>(type: "int", nullable: true),
                    score4 = table.Column<int>(type: "int", nullable: true),
                    score5 = table.Column<int>(type: "int", nullable: true),
                    score6 = table.Column<int>(type: "int", nullable: true),
                    score7 = table.Column<int>(type: "int", nullable: true),
                    score8 = table.Column<int>(type: "int", nullable: true),
                    modescore1 = table.Column<int>(type: "int", nullable: true),
                    modescore2 = table.Column<int>(type: "int", nullable: true),
                    modescore3 = table.Column<int>(type: "int", nullable: true),
                    modescore4 = table.Column<int>(type: "int", nullable: true),
                    dominantmode = table.Column<int>(type: "int", nullable: true),
                    dominanttype = table.Column<int>(type: "int", nullable: true),
                    ndtype1 = table.Column<int>(type: "int", nullable: true),
                    ndtype2 = table.Column<int>(type: "int", nullable: true),
                    ndtype3 = table.Column<int>(type: "int", nullable: true),
                    ndtype4 = table.Column<int>(type: "int", nullable: true),
                    dominantmode2 = table.Column<int>(type: "int", nullable: true),
                    dominanttype2 = table.Column<int>(type: "int", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FinMission = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FMRU = table.Column<int>(type: "int", nullable: true),
                    FMVA = table.Column<int>(type: "int", nullable: true),
                    FMdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FMIntensityImage = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FmIntensityVAMid = table.Column<int>(type: "int", nullable: true),
                    FmIntensityRUMid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exoa_Assessment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EXOA_FinMission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Xcell = table.Column<int>(type: "int", nullable: true),
                    Ycell = table.Column<int>(type: "int", nullable: true),
                    FM = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    RUCategoryId = table.Column<int>(type: "int", nullable: true),
                    VACategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXOA_FinMission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EXOA_QAAssessments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertifiedByAdminLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenCertified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calibration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QType1Answer = table.Column<int>(type: "int", nullable: true),
                    QType2Answer = table.Column<int>(type: "int", nullable: true),
                    QType3Answer = table.Column<int>(type: "int", nullable: true),
                    QType4Answer = table.Column<int>(type: "int", nullable: true),
                    QType5Answer = table.Column<int>(type: "int", nullable: true),
                    QType6Answer = table.Column<int>(type: "int", nullable: true),
                    QType7Answer = table.Column<int>(type: "int", nullable: true),
                    QType8Answer = table.Column<int>(type: "int", nullable: true),
                    Score1 = table.Column<int>(type: "int", nullable: true),
                    Score2 = table.Column<int>(type: "int", nullable: true),
                    Score3 = table.Column<int>(type: "int", nullable: true),
                    Score4 = table.Column<int>(type: "int", nullable: true),
                    Score5 = table.Column<int>(type: "int", nullable: true),
                    Score6 = table.Column<int>(type: "int", nullable: true),
                    Score7 = table.Column<int>(type: "int", nullable: true),
                    Score8 = table.Column<int>(type: "int", nullable: true),
                    ModeScore1 = table.Column<int>(type: "int", nullable: true),
                    ModeScore2 = table.Column<int>(type: "int", nullable: true),
                    ModeScore3 = table.Column<int>(type: "int", nullable: true),
                    ModeScore4 = table.Column<int>(type: "int", nullable: true),
                    DominantMode = table.Column<int>(type: "int", nullable: true),
                    DominantType = table.Column<int>(type: "int", nullable: true),
                    DominantMode2 = table.Column<int>(type: "int", nullable: true),
                    DominantType2 = table.Column<int>(type: "int", nullable: true),
                    NdType1 = table.Column<int>(type: "int", nullable: true),
                    NdType2 = table.Column<int>(type: "int", nullable: true),
                    NdType3 = table.Column<int>(type: "int", nullable: true),
                    NdType4 = table.Column<int>(type: "int", nullable: true),
                    FinMission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FMRU = table.Column<int>(type: "int", nullable: true),
                    FMVA = table.Column<int>(type: "int", nullable: true),
                    FMIntensityImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FmIntensityVAMid = table.Column<int>(type: "int", nullable: true),
                    FmIntensityRUMid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXOA_QAAssessments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exoa_Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PID = table.Column<long>(type: "bigint", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Question = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    EnterDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnsTextLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnsTextRight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exoa_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExoaExplanations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    condition = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Explanation1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefrences = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    prefexpl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lstyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lstylec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Explanation1c = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExoaExplanations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExoaModes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Expl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDExpl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExoaModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EXOAQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnsLeft = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AnsRight = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    TieBreaking = table.Column<bool>(type: "bit", nullable: false),
                    A = table.Column<int>(type: "int", nullable: true),
                    B = table.Column<int>(type: "int", nullable: true),
                    C = table.Column<int>(type: "int", nullable: true),
                    D = table.Column<int>(type: "int", nullable: true),
                    E = table.Column<int>(type: "int", nullable: true),
                    F = table.Column<int>(type: "int", nullable: true),
                    LastModify = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXOAQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExoaTraits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Trait = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Expl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDExpl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExoaTraits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FOA_Assessment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PID = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TestStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    SumVA = table.Column<int>(type: "int", nullable: true),
                    SumRU = table.Column<int>(type: "int", nullable: true),
                    Past = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Now = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Future = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cnt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOA_Assessment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FOA_Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PID = table.Column<long>(type: "bigint", nullable: true),
                    Q_Num = table.Column<int>(type: "int", nullable: true),
                    Question_Id = table.Column<string>(type: "char(10)", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    QB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QF = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<string>(type: "char(1)", nullable: true),
                    IsGenuine = table.Column<bool>(type: "bit", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    A = table.Column<short>(type: "smallint", nullable: true),
                    B = table.Column<short>(type: "smallint", nullable: true),
                    C = table.Column<short>(type: "smallint", nullable: true),
                    D = table.Column<short>(type: "smallint", nullable: true),
                    E = table.Column<short>(type: "smallint", nullable: true),
                    F = table.Column<short>(type: "smallint", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOA_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FOA_Questions_V2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGenuine = table.Column<bool>(type: "bit", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    A = table.Column<short>(type: "smallint", nullable: true),
                    B = table.Column<short>(type: "smallint", nullable: true),
                    C = table.Column<short>(type: "smallint", nullable: true),
                    D = table.Column<short>(type: "smallint", nullable: true),
                    E = table.Column<short>(type: "smallint", nullable: true),
                    F = table.Column<short>(type: "smallint", nullable: true),
                    QuestionIdRef = table.Column<int>(type: "int", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOA_Questions_V2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FOA_Report",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutiveSummary_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutiveSummary_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutiveSummary_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatureImage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FinancialMission_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialMission_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialMission_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialMission_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialMission_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialMission_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialMission_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialMission_8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialMission_9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancialMission_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuationTrajectoryImage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FutureValuation_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FutureValuation_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FutureValuation_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FutureValuation_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FutureValuation_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrajectoryExplaination_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrajectoryExplaination_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrajectoryExplaination_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrajectoryExplaination_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrajectoryExplaination_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOA_Report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FOA_Results",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PID = table.Column<long>(type: "bigint", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Question = table.Column<int>(type: "int", nullable: true),
                    Question_Id = table.Column<string>(type: "char(10)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    EnterDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnsTextLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnsTextRight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOA_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RU_CategoryID = table.Column<int>(type: "int", nullable: true),
                    VA_CategoryID = table.Column<int>(type: "int", nullable: true),
                    imageTop = table.Column<int>(type: "int", nullable: true),
                    imageLeft = table.Column<int>(type: "int", nullable: true),
                    AssessmentType = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LANGUAGES",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TRANSLATED_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANGUAGES", x => x.RowId);
                    table.UniqueConstraint("AK_LANGUAGES_LanguageId", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PercentAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    LowerBound = table.Column<int>(type: "int", nullable: true),
                    UpperBound = table.Column<int>(type: "int", nullable: true),
                    AssessmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScoreType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTemp = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PercentAssignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PERTH_TERMS",
                columns: table => new
                {
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TERM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TOKEN = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERTH_TERMS", x => x.RowId);
                    table.UniqueConstraint("AK_PERTH_TERMS_PerthTermId", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblAssessmentDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessmentName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAssessmentDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAttachedDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RefrenceType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SavedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DocumentName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContentType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAttachedDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCoachingSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignProjectId = table.Column<int>(type: "int", nullable: true),
                    AssignSubjectId = table.Column<int>(type: "int", nullable: true),
                    PCC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Session = table.Column<int>(type: "int", nullable: true),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionTime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SessionType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SessionStatus = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    POSTQAComplete = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCoachingSession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCreator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCreator", x => x.Id);
                    table.UniqueConstraint("AK_tblCreator_CreatorId", x => x.CreatorId);
                });

            migrationBuilder.CreateTable(
                name: "tblElaExplanation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Condition = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblElaExplanation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblElaMode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Expl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDEXpl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblElaMode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblElaTriats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Trait = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Expl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDExpl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblElaTriats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFmInputScale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    type = table.Column<string>(type: "char(10)", nullable: true),
                    begin = table.Column<double>(type: "float", nullable: true),
                    end = table.Column<double>(type: "float", nullable: true),
                    Super = table.Column<string>(type: "char(10)", nullable: true),
                    sub = table.Column<int>(type: "int", nullable: true),
                    index = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFmInputScale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFmIntensity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vaId = table.Column<long>(type: "bigint", nullable: true),
                    ruId = table.Column<long>(type: "bigint", nullable: true),
                    mode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    indexRU = table.Column<int>(type: "int", nullable: true),
                    indexVA = table.Column<int>(type: "int", nullable: true),
                    FMIntensity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFmIntensity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLicensee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicenseeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLicensee", x => x.Id);
                    table.UniqueConstraint("AK_tblLicensee_LicenseeId", x => x.LicenseeId);
                });

            migrationBuilder.CreateTable(
                name: "tblMenuItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<int>(type: "int", nullable: true),
                    Parent = table.Column<int>(type: "int", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Link = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMenuItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMenuUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activation = table.Column<bool>(type: "bit", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    Privilege = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverAllUserId = table.Column<int>(type: "int", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMenuUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOverAllUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OverAllUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOverAllUsers", x => x.Id);
                    table.UniqueConstraint("AK_tblOverAllUsers_OverallUserId", x => x.OverAllUserId);
                });

            migrationBuilder.CreateTable(
                name: "tblPerthAdminPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPerthAdminPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ProgramType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    OverAllUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgramCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ProgramCountry = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPrograms", x => x.Id);
                    table.UniqueConstraint("AK_tblPrograms_ProgramId", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "tblStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSubjectAssessmentReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignSubjectId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TakenOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Report = table.Column<byte[]>(type: "binary(50)", nullable: true),
                    CouponNo = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubjectAssessmentReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentUserGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentUserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentUserGroups_AssessmentGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "AssessmentGroups",
                        principalColumn: "Groupid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERTH_TERM_TRANSLATIONS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LANGUAGE_ID = table.Column<int>(type: "int", nullable: false),
                    PERTH_TERM_ID = table.Column<int>(type: "int", nullable: false),
                    TRANSLATED_TERM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERTH_TERM_TRANSLATIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PERTH_TERM_TRANSLATIONS_LANGUAGES_LANGUAGE_ID",
                        column: x => x.LANGUAGE_ID,
                        principalTable: "LANGUAGES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERTH_TERM_TRANSLATIONS_PERTH_TERMS_PERTH_TERM_ID",
                        column: x => x.PERTH_TERM_ID,
                        principalTable: "PERTH_TERMS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    ClientCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    Zip = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneNo1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PhoneNo2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Comments = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    BillingAddress1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BillingAddress2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BillingCity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BillingState = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BillingZip = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    BillingCountry = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    BillingPhoneNo1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    BillingPhoneNo2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    IsSameBilling = table.Column<bool>(type: "bit", nullable: true),
                    ShippingAddress1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ShippingAddress2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ShippingCity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ShippingState = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ShippingZip = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ShippingCountry = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ShippingPhone1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ShippingPhone2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    OverAllUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archieve = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClients", x => x.Id);
                    table.UniqueConstraint("AK_tblClients_ClientId", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_tblClients_tblOverAllUsers_OverAllUserId",
                        column: x => x.OverAllUserId,
                        principalTable: "tblOverAllUsers",
                        principalColumn: "OverAllUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Projectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    OverAllUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectManager = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ProjectCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    PMName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ProjectCountry = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjects", x => x.Id);
                    table.UniqueConstraint("AK_tblProjects_ProjectId", x => x.Projectid);
                    table.ForeignKey(
                        name: "FK_tblProjects_tblPrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "tblPrograms",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblAssignProgram",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    OverAllUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAssignProgram", x => x.Id);
                    table.UniqueConstraint("AK_tblAssignProgram_AssignedProgramId", x => x.AssignedProgramId);
                    table.ForeignKey(
                        name: "FK_tblAssignProgram_tblClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tblClients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAssignProgram_tblPrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "tblPrograms",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblClientContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Salutation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    Zip = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    OverAllUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClientContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblClientContacts_tblClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tblClients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCoupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponNo = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    CouponType = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    DaysToExpire = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    LicenseeId = table.Column<int>(type: "int", nullable: true),
                    SubjectReport = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    Series = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponLimit = table.Column<short>(type: "smallint", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    AssessmentType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserReport = table.Column<bool>(type: "bit", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCoupons", x => x.Id);
                    table.UniqueConstraint("AK_tblCoupons_CouponId", x => x.CouponId);
                    table.ForeignKey(
                        name: "FK_tblCoupons_tblClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tblClients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCoupons_tblCreator_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "tblCreator",
                        principalColumn: "CreatorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCoupons_tblLicensee_LicenseeId",
                        column: x => x.LicenseeId,
                        principalTable: "tblLicensee",
                        principalColumn: "LicenseeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PID = table.Column<long>(type: "bigint", nullable: true),
                    Salutation = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    AsstBeginDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    AsstEndDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Address1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Zip = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Phone1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    Dept = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Designation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PositionLevel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Age = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Education = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AreaEndeavor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Experience = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Industry = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SizeRevenue = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OrganizationSize = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    OverallUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Financialmission = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ObsProf = table.Column<int>(type: "int", nullable: true),
                    ObsLead = table.Column<int>(type: "int", nullable: true),
                    ObsManage = table.Column<int>(type: "int", nullable: true),
                    ObsMission = table.Column<int>(type: "int", nullable: true),
                    FmIntensityVAMid = table.Column<int>(type: "int", nullable: true),
                    FmIntensityRUMid = table.Column<int>(type: "int", nullable: true),
                    FMIntensityImage = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NewPassword = table.Column<bool>(type: "bit", nullable: true),
                    ViewRelease = table.Column<bool>(type: "bit", nullable: true),
                    Organization = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UserType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubjects", x => x.Id);
                    table.UniqueConstraint("AK_tblSubjects_SubjectId", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_tblSubjects_tblClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tblClients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblSubjects_tblOverAllUsers_OverallUserId",
                        column: x => x.OverallUserId,
                        principalTable: "tblOverAllUsers",
                        principalColumn: "OverAllUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblAssignProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    AssignProgramId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewMessage = table.Column<bool>(type: "bit", nullable: true),
                    ThankYouLetter = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportsGenerated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportsSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryConfirm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QRAvailable = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportBcc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlanRequired = table.Column<bool>(type: "bit", nullable: true),
                    ReportLocation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DraftSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalPlan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportPrinted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAssignProjects", x => x.Id);
                    table.UniqueConstraint("AK_tblAssignProjects_AssignProjectId", x => x.AssignProjectId);
                    table.ForeignKey(
                        name: "FK_tblAssignProjects_tblAssignProgram_AssignProgramId",
                        column: x => x.AssignProgramId,
                        principalTable: "tblAssignProgram",
                        principalColumn: "AssignedProgramId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAssignProjects_tblProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "tblProjects",
                        principalColumn: "Projectid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblAssignSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    AssignProjectId = table.Column<int>(type: "int", nullable: false),
                    OverAllUserId = table.Column<int>(type: "int", nullable: false),
                    ReportAccess = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAssignSubjects", x => x.Id);
                    table.UniqueConstraint("AK_tblAssignSubjects_AssignSubjectId", x => x.AssignSubjectId);
                    table.ForeignKey(
                        name: "FK_tblAssignSubjects_tblAssignProjects_AssignProjectId",
                        column: x => x.AssignProjectId,
                        principalTable: "tblAssignProjects",
                        principalColumn: "AssignProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAssignSubjects_tblSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "tblSubjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblAssignCoupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SentBy = table.Column<int>(type: "int", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    AssignSubjectId = table.Column<int>(type: "int", nullable: true),
                    AssessmentType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ConfirmDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAssignCoupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAssignCoupons_tblAssignSubjects_AssignSubjectId",
                        column: x => x.AssignSubjectId,
                        principalTable: "tblAssignSubjects",
                        principalColumn: "AssignSubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAssignCoupons_tblCoupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "tblCoupons",
                        principalColumn: "CouponId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAssignCoupons_tblSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "tblSubjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentUserGroups_GroupId",
                table: "AssessmentUserGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UNIQUE_Exam_Terms",
                table: "Exam_Terms",
                columns: new[] { "Exam", "Culture" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UNIQUE_LANGUAGE_NAME",
                table: "LANGUAGES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PERTH_TERM_TRANSLATIONS_PERTH_TERM_ID",
                table: "PERTH_TERM_TRANSLATIONS",
                column: "PERTH_TERM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UNIQUE_PERTH_TERM_TRANSLATIONS",
                table: "PERTH_TERM_TRANSLATIONS",
                columns: new[] { "LANGUAGE_ID", "PERTH_TERM_ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UNIQUE_PERTH_TERM",
                table: "PERTH_TERMS",
                column: "TERM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignCoupons_AssignSubjectId",
                table: "tblAssignCoupons",
                column: "AssignSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignCoupons_CouponId",
                table: "tblAssignCoupons",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignCoupons_SubjectId",
                table: "tblAssignCoupons",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignProgram_ClientId",
                table: "tblAssignProgram",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignProgram_ProgramId",
                table: "tblAssignProgram",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignProjects_AssignProgramId",
                table: "tblAssignProjects",
                column: "AssignProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignProjects_ProjectId",
                table: "tblAssignProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignSubjects_AssignProjectId",
                table: "tblAssignSubjects",
                column: "AssignProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignSubjects_SubjectId",
                table: "tblAssignSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tblClientContacts_ClientId",
                table: "tblClientContacts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblClients_OverAllUserId",
                table: "tblClients",
                column: "OverAllUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCoupons_ClientId",
                table: "tblCoupons",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCoupons_CreatorId",
                table: "tblCoupons",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCoupons_LicenseeId",
                table: "tblCoupons",
                column: "LicenseeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProjects_ProgramId",
                table: "tblProjects",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSubjects_ClientId",
                table: "tblSubjects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSubjects_OverallUserId",
                table: "tblSubjects",
                column: "OverallUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "AdminLog");

            migrationBuilder.DropTable(
                name: "AssessmentSignatures");

            migrationBuilder.DropTable(
                name: "AssessmentUserGroups");

            migrationBuilder.DropTable(
                name: "CFOA_Assessment");

            migrationBuilder.DropTable(
                name: "cFOA_Questions");

            migrationBuilder.DropTable(
                name: "CFOA_Questions_V2");

            migrationBuilder.DropTable(
                name: "CFOA_Results");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "ELA_Assessment");

            migrationBuilder.DropTable(
                name: "ELA_Results");

            migrationBuilder.DropTable(
                name: "Exam_Terms");

            migrationBuilder.DropTable(
                name: "Exoa_Assessment");

            migrationBuilder.DropTable(
                name: "EXOA_FinMission");

            migrationBuilder.DropTable(
                name: "EXOA_QAAssessments");

            migrationBuilder.DropTable(
                name: "Exoa_Results");

            migrationBuilder.DropTable(
                name: "ExoaExplanations");

            migrationBuilder.DropTable(
                name: "ExoaModes");

            migrationBuilder.DropTable(
                name: "EXOAQuestions");

            migrationBuilder.DropTable(
                name: "ExoaTraits");

            migrationBuilder.DropTable(
                name: "FOA_Assessment");

            migrationBuilder.DropTable(
                name: "FOA_Questions");

            migrationBuilder.DropTable(
                name: "FOA_Questions_V2");

            migrationBuilder.DropTable(
                name: "FOA_Report");

            migrationBuilder.DropTable(
                name: "FOA_Results");

            migrationBuilder.DropTable(
                name: "ImageSettings");

            migrationBuilder.DropTable(
                name: "PercentAssignments");

            migrationBuilder.DropTable(
                name: "PERTH_TERM_TRANSLATIONS");

            migrationBuilder.DropTable(
                name: "tblAssessmentDefinitions");

            migrationBuilder.DropTable(
                name: "tblAssignCoupons");

            migrationBuilder.DropTable(
                name: "tblAttachedDocuments");

            migrationBuilder.DropTable(
                name: "tblClientContacts");

            migrationBuilder.DropTable(
                name: "tblCoachingSession");

            migrationBuilder.DropTable(
                name: "tblElaExplanation");

            migrationBuilder.DropTable(
                name: "tblElaMode");

            migrationBuilder.DropTable(
                name: "tblElaTriats");

            migrationBuilder.DropTable(
                name: "tblFmInputScale");

            migrationBuilder.DropTable(
                name: "tblFmIntensity");

            migrationBuilder.DropTable(
                name: "tblMenuItem");

            migrationBuilder.DropTable(
                name: "tblMenuUsers");

            migrationBuilder.DropTable(
                name: "tblPerthAdminPermissions");

            migrationBuilder.DropTable(
                name: "tblStates");

            migrationBuilder.DropTable(
                name: "tblSubjectAssessmentReports");

            migrationBuilder.DropTable(
                name: "AssessmentGroups");

            migrationBuilder.DropTable(
                name: "LANGUAGES");

            migrationBuilder.DropTable(
                name: "PERTH_TERMS");

            migrationBuilder.DropTable(
                name: "tblAssignSubjects");

            migrationBuilder.DropTable(
                name: "tblCoupons");

            migrationBuilder.DropTable(
                name: "tblAssignProjects");

            migrationBuilder.DropTable(
                name: "tblSubjects");

            migrationBuilder.DropTable(
                name: "tblCreator");

            migrationBuilder.DropTable(
                name: "tblLicensee");

            migrationBuilder.DropTable(
                name: "tblAssignProgram");

            migrationBuilder.DropTable(
                name: "tblProjects");

            migrationBuilder.DropTable(
                name: "tblClients");

            migrationBuilder.DropTable(
                name: "tblPrograms");

            migrationBuilder.DropTable(
                name: "tblOverAllUsers");
        }
    }
}
