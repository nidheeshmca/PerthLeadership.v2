# Database Consolidation Recommendation

## Current State: 4 Separate Databases

| Database | Tables | Stored Procedures | Purpose |
|---|---|---|---|
| ELMAH | 1 | 3 | Error logging (legacy) |
| LARM_Document | 1 | 8 | File/document storage |
| LARM_Client1 | ~95 | ~100 | Assessment engines (FOA, CFOA, EXOA, ELA), users, groups, coupons, affiliates |
| LARM_MasterDB | ~75 | ~150 | Master data: clients, subjects, programs, projects, coupons, report content, assessment config |

## Recommendation: Consolidate into a Single Unified Database

### Justification

1. **No cross-database foreign keys exist today** — the original design used OPENQUERY/linked servers to join across databases. This is fragile and prevents referential integrity enforcement.

2. **Significant table duplication** — both LARM_Client1 and LARM_MasterDB contain:
   - FOA/CFOA signature tables, percent assignment tables
   - EXOA explanation, mode, and traits tables
   - Error log tables (identical schema)
   - Menu item/user tables

3. **ELMAH is obsolete** — replaced by modern structured logging (Serilog + Seq/Application Insights).

4. **LARM_Document has a single table** — trivially merged into the main schema.

5. **Single DbContext simplifies**:
   - Transaction management (no distributed transactions)
   - Migration management (one migration history)
   - Query composition (joins across all tables)
   - Connection string management

### Consolidation Strategy

#### Tables REMOVED (replaced by modern alternatives):
- `ELMAH_Error` → Replace with Serilog structured logging
- `tblErrorLog` (both databases) → Replace with Serilog
- `old_CFOA_Results`, `old_FOA_Results` → Archive/historical, not migrated to entities
- `tbltest`, `tblPerthTemp` → Temporary/test tables, not migrated
- `deluser` → Soft-delete pattern instead

#### Tables MERGED (duplicates across databases resolved):
- CFOA_Signature, FOA_Signature → Unified with `AssessmentType` discriminator
- CFOA/FOA PercentAssignment_RU/VA → Unified with `AssessmentType` discriminator
- CFOA/FOA TempPercentAssignment → Unified with `AssessmentType` discriminator
- EXOAexplanation + EXOAexplanation_M → Single table with `ModelType` column
- EXOAMode + EXOAMode_M → Single table with `ModelType` column
- EXOATraits + EXOATraits_M → Single table with `ModelType` column
- Chinese language variant tables → Unified via `LanguageCode` column

#### Schema Organization (by EF Core schema/prefix):

| Schema Area | Tables | Source DB |
|---|---|---|
| Core Identity | Subjects, OverAllUsers, Clients, ClientContacts | MasterDB |
| Programs | Programs, Projects, AssignProgram, AssignProjects, AssignSubjects | MasterDB |
| Coupons | Coupons (new), AssignCoupons, Assessments | MasterDB |
| FOA Assessment | FOA_Assessment, FOA_Questions, FOA_Results, FOA_Report*, FOA_Signature, FOA_ImageSetting, FOA_PercentAssignment | Client1 + MasterDB |
| CFOA Assessment | CFOA_Assessment, CFOA_Questions, CFOA_Results, CFOA_Signature, CFOA_ImageSetting, CFOA_PercentAssignment | Client1 + MasterDB |
| EXOA Assessment | EXOA_Assessment, EXOA_Questions, EXOA_Results, EXOA_Explanation, EXOA_Mode, EXOA_Traits, EXOA_FinMission | Client1 + MasterDB |
| ELA Assessment | ELA_Assessment, ELA_Results, ELA_Explanation, ELA_Mode, ELA_Traits | Client1 + MasterDB |
| Admin | Admin, AdminLog, MenuItems, MenuUsers, PerthAdminPermissions | Client1 + MasterDB |
| Reporting | ManageReports, SubjectAssessmentReports, FmIntensity, FmInputScale | MasterDB |
| Documents | AttachedDocuments | LARM_Document |
| Lookup | Countries, States, Languages, PerthTerms, PerthTermTranslations, ExamTerms | Both |
| Legacy Coupons | Coupons (old Client1 table) | Client1 |
| Groups | FOA_Group, CFOA_Group, EXOA_D1_Group, EXOA_D2_Group + UserGroup tables | Client1 |
| Affiliates | tblaff_* tables | Client1 |

### Naming Conflicts Resolved

| Conflict | Resolution |
|---|---|
| `Coupons` (Client1) vs `tblCoupons` (MasterDB) | Client1 `Coupons` → `LegacyCoupons`; MasterDB `tblCoupons` → `Coupons` (primary) |
| `tblErrorLog` in both DBs | Removed — replaced by Serilog |
| `tblMenuItem` in both DBs | Single table, MasterDB version is canonical |
| `FOA_Signature` in both DBs | Identical schema — merged to single table |
| Assessment result tables in both DBs | MasterDB versions are canonical (have FK relationships) |

### Breaking Changes & Warnings

1. **OPENQUERY/Linked Server references** in stored procedures must be eliminated — all data is now in one database
2. **Windows Registry connection strings** replaced by `appsettings.json` configuration
3. **Dynamic SQL in stored procedures** (e.g., `Sp_GetReturnParameter`, `Sp_tblAttachedDocuments_SearchDocuments`) — security risk, replaced with parameterized EF Core queries
4. **Image data type** in `tblAttachedDocuments.content` → migrated to `varbinary(max)` / `byte[]`
5. **ntext columns** throughout → migrated to `nvarchar(max)` / `string`
