# Stored Procedure Categorization & Migration Plan

## Category Legend
- **CRUD** → Replaced by EF Core repository methods
- **BUSINESS** → Ported to C# service classes
- **RAW SQL** → Retained as raw SQL via `Database.SqlQueryRaw<T>()` or kept as SP calls
- **REMOVED** → Obsolete, dynamic SQL security risk, or replaced by modern alternatives

---

## LARM_MasterDB Stored Procedures

### Subjects (→ SubjectService)
| SP Name | Category | Replacement |
|---|---|---|
| sp_tblSubjects_INS | CRUD | `IRepository<Subject>.AddAsync()` |
| sp_tblSubjects_SEL | CRUD | `IRepository<Subject>.GetByIdAsync()` |
| sp_tblSubjects_SELALL | CRUD | `IRepository<Subject>.GetAllAsync()` |
| sp_tblSubjects_SELALLSubjects | CRUD | `SubjectService.GetAllAsync()` with joins |
| sp_tblSubjects_SELUnassigned | BUSINESS | `SubjectService.GetUnassignedAsync()` - EF Core LINQ query |
| sp_tblSubjects_UPD | CRUD | `IRepository<Subject>.UpdateAsync()` |
| sp_tblSubjects_DEL | CRUD | `IRepository<Subject>.DeleteAsync()` |
| sp_tblSubjects_DELWithArray | CRUD | `ExecuteDeleteAsync()` with `Where(s => ids.Contains(s.SubjectId))` |
| sp_tblSubjects_DELALL | REMOVED | Dangerous bulk delete — not migrated |
| Sp_getLarmUserByEmail | BUSINESS | `SubjectService.GetByEmailAsync()` |
| Sp_getValidateLarmUser | BUSINESS | `SubjectService.ValidateLoginAsync()` |

### Clients (→ ClientService)
| SP Name | Category | Replacement |
|---|---|---|
| sp_tblClients_INS | CRUD | `IRepository<ClientOrganization>.AddAsync()` |
| sp_tblClients_SEL | CRUD | `IRepository<ClientOrganization>.GetByIdAsync()` |
| sp_tblClients_SELALL | CRUD | `IRepository<ClientOrganization>.GetAllAsync()` |
| sp_tblClients_SELByOverAllId | BUSINESS | EF Core LINQ with `Where(c => c.OverAllUserId == id)` |
| sp_tblClients_SELViewDetails | BUSINESS | `ClientService.GetDetailAsync()` with Include() |
| sp_tblClients_UPD | CRUD | Repository update |
| sp_tblClients_UPDWithArray | BUSINESS | Batch update via `ExecuteUpdateAsync()` |
| sp_tblClients_DEL | CRUD | Repository delete |
| sp_deleteClinetInfo | BUSINESS | `ClientService.DeleteAsync()` — cascading delete logic ported to C# with transaction |

### Coupons (→ CouponService)
| SP Name | Category | Replacement |
|---|---|---|
| sp_tblCoupons_INS/SEL/SELALL/UPD/DEL | CRUD | Repository methods |
| sp_tblAssignCoupons_INS | CRUD | Repository add |
| sp_tblAssignCoupons_SEL | BUSINESS | EF Core query with joins to Subject and Coupon |
| sp_tblAssignCoupons_SELBYId | CRUD | Repository GetById |
| sp_tblAssignCoupons_SELProjectSummary | BUSINESS | `CouponService` — complex join ported to LINQ |
| sp_tblAssignCoupons_UPD | CRUD | Repository update |

### Programs & Projects (→ ProgramService, ProjectService)
| SP Name | Category | Replacement |
|---|---|---|
| sp_tblPrograms_INS/SEL/SELALL/UPD/DEL | CRUD | Repository methods |
| sp_tblPrograms_SELByClientId | BUSINESS | EF Core LINQ through AssignProgram |
| sp_tblPrograms_SELALLPrograms | BUSINESS | Distinct programs query |
| sp_tblPrograms_SELALLProgramsForClient | BUSINESS | Join through AssignProgram where ClientId = X |
| sp_tblProjects_INS/SEL/SELALL/UPD/DEL | CRUD | Repository methods |
| sp_tblProjects_SELByProgramId | BUSINESS | EF Core LINQ filter |
| sp_tblProjects_SELByClientId | BUSINESS | Join through AssignProgram |
| sp_tblProjects_SELBySubjectId | BUSINESS | Join through AssignSubject/AssignProject |
| sp_tblProjects_SELALLProjectsForClient | BUSINESS | Complex join ported to LINQ |
| sp_ProjectSummary_By_ProjectId | RAW SQL | **Complex — uses OPENQUERY to linked server, cursor-based. Ported to C# service with multiple EF Core queries. The linked server calls are eliminated since all data is now in one DB.** |

### Assign Programs/Projects/Subjects
| SP Name | Category | Replacement |
|---|---|---|
| sp_tblAssignProgram_* | CRUD | Repository methods |
| sp_tblAssignProjects_* | CRUD | Repository methods |
| sp_tblAssignSubjects_* | CRUD | Repository methods |
| sp_tblAssignSubjects_UPDWithArray | BUSINESS | `ExecuteUpdateAsync()` batch update |

### Coaching Sessions
| SP Name | Category | Replacement |
|---|---|---|
| sp_tblCoachingSession_* | CRUD | Repository methods |
| sp_tblCoachingSession_SELSessionByAsubId | BUSINESS | EF Core LINQ filter |
| sp_tblCoachingSession_SELSummaryByProjectId | BUSINESS | Join and aggregate query |

### Reporting (→ ReportService)
| SP Name | Category | Replacement |
|---|---|---|
| Sp_getFmIntensityImage | BUSINESS | `ReportService.GetFmIntensityImageAsync()` — triple join ported to LINQ |
| SP_CFORAGETIMAGE / SP_FORAGETIMAGE | BUSINESS | `ReportService.GetSignatureAsync()` — percent assignment lookup ported to LINQ |
| sp_tblFmIntensity_* | CRUD | Repository methods |
| sp_tblFmInputScale_* | CRUD | Repository methods |

### Error Log
| SP Name | Category | Replacement |
|---|---|---|
| sp_tblErrorLog_* | REMOVED | Replaced by Serilog structured logging |

### Menu & Permissions (→ AdminService)
| SP Name | Category | Replacement |
|---|---|---|
| sp_tblMenuItem_* | CRUD | Repository methods |
| sp_tblMenuItem_GetItems | BUSINESS | EF Core hierarchical query |
| sp_tblMenuItem_GetItemDetails_ByUserName | BUSINESS | Join with permission check |
| sp_tblMenuUser_* | CRUD | Repository methods |
| sp_tblPerthAdminPermissions_* | CRUD | Repository methods |

### Other Master Tables
| SP Name | Category | Replacement |
|---|---|---|
| sp_tblCreator_* | CRUD | Repository methods |
| sp_tblLicensee_* | CRUD | Repository methods |
| sp_tblStates_* | CRUD | Repository methods |
| sp_tblDocuments_* | CRUD | Repository methods |
| sp_tblMessages_*, sp_tblMessageType_* | CRUD | Repository methods |
| sp_tblNotes_* | CRUD | Repository methods |
| sp_tblOverAllUsers_* | CRUD | Repository methods |
| Sp_tblAssessment_SEARCH | REMOVED | Dynamic SQL (`exec(@strQuery)`) — security risk. Replaced with parameterized LINQ queries |
| Sp_GetReturnParameter | REMOVED | Pure dynamic SQL (`exec(@strQuery)`) — security risk. Not migrated |

### Functions
| Function Name | Category | Replacement |
|---|---|---|
| Get_Assessments_By_SubjectID | BUSINESS | LINQ query joining AssignCoupons with assessment status |
| Get_AssessmentsStatusByParticpinat | BUSINESS | LINQ query with string split replacement |
| Get_Assessments_By_SortAssessmentType | BUSINESS | LINQ OrderBy with assessment type |
| Split | REMOVED | Use C# `string.Split()` or EF Core `string_split` |

---

## LARM_Client1 Stored Procedures

### FOA Assessment (→ AssessmentService)
| SP Name | Category | Replacement |
|---|---|---|
| SP_FOAInsertAssessment | BUSINESS | `AssessmentService.StartAssessmentAsync()` — creates FOA_Assessment record |
| SP_FOAInsertQuestion | BUSINESS | `AssessmentService.SubmitAnswerAsync()` — inserts FOA_Results |
| SP_FOAShowUserStatus | BUSINESS | `AssessmentService.GetUserStatusAsync()` |
| SP_FOAUSERDETAIL | BUSINESS | EF Core query with user details |
| SP_FOASelectVersion | BUSINESS | Version lookup query |
| SP_SelectAllFOAVersion | CRUD | Repository query |
| SP_FOACommitLive | BUSINESS | Batch update from V2 to live questions |
| SP_FOAUpdateQuestionID | CRUD | Update question |
| SP_FOAUpdateOnlineQuestionID | CRUD | Update question |
| SP_FOAGETSignature | BUSINESS | `ReportService.GetSignatureAsync()` |
| SP_FORAGETIMAGE | BUSINESS | `ReportService.GetFmIntensityImageAsync()` |
| SP_GetFOASignature | BUSINESS | Signature lookup |

### CFOA Assessment (→ AssessmentService)
| SP Name | Category | Replacement |
|---|---|---|
| SP_CFOAInsertAssessment | BUSINESS | `AssessmentService.StartAssessmentAsync()` |
| SP_CFOASelectQuestion | CRUD | Questions query |
| SP_CFOASelectOnlineQuestion | CRUD | Online questions query |
| SP_CFOASelectQuestionid | CRUD | Question by ID |
| SP_CFOACheckUpdateQuestion | BUSINESS | Check/update status |
| SP_CFOACommitLive | BUSINESS | Batch update V2 → live (uses dynamic SQL — ported to parameterized) |
| SP_CFOACOUNTCATEGORY | BUSINESS | `GroupBy` + `Count` LINQ query |
| SP_CFOAGetGroupUsers | BUSINESS | Group membership query |
| SP_CFOAGETSignature | BUSINESS | Signature lookup |
| SP_CFORAGETIMAGE | BUSINESS | Image coordinate lookup |
| SP_CFOASelectTermsCondition | CRUD | Terms query |
| SP_CFOASelectUsers | CRUD | Users query |
| SP_CFOAShowUserStatus | BUSINESS | User status check |
| SP_CFOAUSERDETAIL | BUSINESS | User detail with joins |
| SP_CFOAUpdateCouponUsersAssessment | BUSINESS | Complex update logic |
| SP_CFOASelectVersion | BUSINESS | Version lookup |
| SP_CfoaSelectedUsers | BUSINESS | Selected users query |

### EXOA Assessment (→ AssessmentService)
| SP Name | Category | Replacement |
|---|---|---|
| SP_EXOACommitLive | BUSINESS | Batch update V2 → live |
| SP_EXOAShowUserStatus | BUSINESS | User status check |
| SP_EXOAUSERDETAIL | BUSINESS | User detail |
| SP_EXOAUpdateQuestionID | CRUD | Question update |
| SP_EXOASelectVersion | BUSINESS | Version lookup |
| SP_SelectAllEXOAVersion | CRUD | Repository query |

### Groups (→ AssessmentService/ReportService)
| SP Name | Category | Replacement |
|---|---|---|
| sp_createGroup / sp_createFoaGroup / sp_createExoaGroup | BUSINESS | `AssessmentService` — group creation with member assignment |
| sp_checkGroup / sp_checkFoaGroup / sp_checkExoaGroup | BUSINESS | Existence check queries |
| sp_getGroupDetail / sp_getFoaGroupDetail / sp_getExoaGroupDetail | BUSINESS | Group detail queries |
| sp_returnGroupId / sp_returnFoaGroupId / sp_returnExoaGroupId | BUSINESS | Group ID lookup |
| sp_GetGroupUsers / sp_GetFoaGroupUsers / sp_GetExoaGroupUsers | BUSINESS | Member listing |
| sp_updateGroup | BUSINESS | Group update with recalculation |
| SP_Foagroupscoredetail | RAW SQL | **Complex reporting query — kept as raw SQL** |
| SP_groupscoredetail | RAW SQL | **Complex reporting query — kept as raw SQL** |
| SP_Exoa_d1_groupscoredetail | RAW SQL | **Complex reporting query — kept as raw SQL** |
| SP_Exoa_d2_groupscoredetail | RAW SQL | **Complex reporting query — kept as raw SQL** |
| Sp_GroupDistributionSummary | RAW SQL | **Complex reporting with aggregates — kept as raw SQL** |
| sp_createGroupsforGroupSummary | BUSINESS | Group summary creation |

### Admin (→ AdminService)
| SP Name | Category | Replacement |
|---|---|---|
| sp_GetAdminUser | BUSINESS | `AdminService.VerifyAdminAsync()` |
| sp_GetAdminUserDetail / sp_GetAdminUserDetails | CRUD | Repository queries |
| sp_InsertAdminUsers | CRUD | Repository add |
| sp_UpdateAdminUser | CRUD | Repository update |
| sp_DeleteAdminUser | CRUD | Repository delete |
| sp_VerifyUser | BUSINESS | Authentication check |
| sp_GetAllUsers | CRUD | Repository query |

### Menu System (→ AdminService)
| SP Name | Category | Replacement |
|---|---|---|
| sp_AddMenuItem | BUSINESS | Upsert logic ported to C# |
| sp_DeleteMenuItem / sp_DeleteParent | CRUD | Repository delete |
| sp_GetItems / sp_GetMenuContents | BUSINESS | Hierarchical menu query |
| sp_MenuHeaders / sp_MainMenuDetails | BUSINESS | Menu structure queries |
| sp_SaveUserAccess / sp_SaveUserAcces | BUSINESS | Permission assignment |
| sp_ManageConnections | REMOVED | Registry-based connection management — replaced by appsettings.json |

### Data Copy/Migration
| SP Name | Category | Replacement |
|---|---|---|
| sp_CopyUsersData / sp_CopyUsersDataTest | REMOVED | One-time migration scripts — not needed in new system |
| sp_DuplicateData / sp_InsertDuplicateData | REMOVED | Data dedup scripts |
| SP_GetMigrationUsers / SP_MigrationSelectUsers | REMOVED | Migration utilities |
| sp_flush_user_data | BUSINESS | User data cleanup — ported with transaction safety |
| sp_delCFOAProfile | BUSINESS | Profile deletion — ported to service |

### Affiliates
| SP Name | Category | Replacement |
|---|---|---|
| spafw_* (all affiliate SPs) | CRUD/BUSINESS | Ported to AffiliateService if needed, or deferred if affiliate system is deprecated |

### MRI Assessment
| SP Name | Category | Replacement |
|---|---|---|
| SP_MRI* | BUSINESS | Ported to AssessmentService if MRI assessments are still active |

### Misc
| SP Name | Category | Replacement |
|---|---|---|
| sp_CountClick | CRUD | Simple increment |
| sp_UpdateImpressions | CRUD | Simple increment |
| sp_tblErrorLog_* | REMOVED | Replaced by Serilog |
| sp_SelectAllDatabase | REMOVED | Admin utility — not needed |
| sp_SelectMRI | CRUD | Repository query |

---

## LARM_Document Stored Procedures

| SP Name | Category | Replacement |
|---|---|---|
| sp_tblAttachedDocuments_INS | CRUD | `IRepository<AttachedDocument>.AddAsync()` |
| sp_tblAttachedDocuments_SEL | CRUD | `IRepository<AttachedDocument>.GetByIdAsync()` |
| sp_tblAttachedDocuments_SELALL | CRUD | `IRepository<AttachedDocument>.GetAllAsync()` |
| sp_tblAttachedDocuments_UPD | CRUD | Repository update |
| sp_tblAttachedDocuments_DEL | CRUD | Repository delete |
| sp_tblAttachedDocuments_DELALL | REMOVED | Dangerous bulk delete |
| sp_tblAttachedDocuments_DELWithArray | CRUD | `ExecuteDeleteAsync()` with Contains |
| Sp_tblAttachedDocuments_SearchDocuments | REMOVED | **Dynamic SQL security risk** (`EXEC(@strQuery)`) — replaced with parameterized EF Core queries |

---

## ELMAH Stored Procedures

| SP Name | Category | Replacement |
|---|---|---|
| ELMAH_LogError | REMOVED | Replaced by Serilog |
| ELMAH_GetErrorXml | REMOVED | Replaced by Serilog |
| ELMAH_GetErrorsXml | REMOVED | Replaced by Serilog |

---

## Summary Statistics

| Category | Count | Notes |
|---|---|---|
| CRUD → Repository | ~120 | Standard CRUD operations replaced by generic repository |
| BUSINESS → Service | ~60 | Business logic ported to typed C# service methods |
| RAW SQL → Retained | ~5 | Complex reporting queries with aggregates/cursors |
| REMOVED | ~25 | Dynamic SQL risks, obsolete utilities, replaced by modern alternatives |

## Complex SPs Retained as Raw SQL

These stored procedures contain complex logic that is better served as raw SQL via `Database.SqlQueryRaw<T>()`:

1. **SP_Foagroupscoredetail** — Group score reporting with complex aggregations
2. **SP_groupscoredetail** — Generic group score detail
3. **SP_Exoa_d1_groupscoredetail** — EXOA dimension 1 group scores
4. **SP_Exoa_d2_groupscoredetail** — EXOA dimension 2 group scores
5. **Sp_GroupDistributionSummary** — Distribution analysis with statistical calculations

**Rationale**: These SPs perform complex set-based operations with multiple temporary tables, cursors, and statistical calculations that would be inefficient or overly complex to express in LINQ. They are read-only reporting queries with no write side effects, making them safe to retain as raw SQL.
