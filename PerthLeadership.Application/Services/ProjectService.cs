using Microsoft.EntityFrameworkCore;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;
using PerthLeadership.Domain.Entities.Client;
using PerthLeadership.Domain.Exceptions;
using PerthLeadership.Domain.Interfaces;

namespace PerthLeadership.Application.Services;

public sealed class ProjectService(
    IRepository<Project> projectRepository,
    IRepository<AssignProject> assignProjectRepository,
    IRepository<AssignProgram> assignProgramRepository,
    IUnitOfWork unitOfWork) : IProjectService
{
    public async Task<ProjectDto?> GetByIdAsync(int projectId, CancellationToken cancellationToken = default)
    {
        return await projectRepository.Query()
            .AsNoTracking()
            .Where(p => p.ProjectId == projectId)
            .Select(p => new ProjectDto(
                p.ProjectId, p.ProjectName, p.ProgramId,
                p.StartDate, p.EndDate, p.Status))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ProjectDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await projectRepository.Query()
            .AsNoTracking()
            .OrderByDescending(p => p.CreatedOn)
            .Select(p => new ProjectDto(
                p.ProjectId, p.ProjectName, p.ProgramId,
                p.StartDate, p.EndDate, p.Status))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ProjectDto>> GetByProgramIdAsync(int programId, CancellationToken cancellationToken = default)
    {
        return await projectRepository.Query()
            .AsNoTracking()
            .Where(p => p.ProgramId == programId)
            .OrderByDescending(p => p.CreatedOn)
            .Select(p => new ProjectDto(
                p.ProjectId, p.ProjectName, p.ProgramId,
                p.StartDate, p.EndDate, p.Status))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ProjectDto>> GetByClientIdAsync(int clientId, CancellationToken cancellationToken = default)
    {
        return await assignProgramRepository.Query()
            .AsNoTracking()
            .Where(ap => ap.ClientId == clientId)
            .SelectMany(ap => ap.AssignProjects)
            .Select(apj => new ProjectDto(
                apj.Project!.ProjectId, apj.Project.ProjectName, apj.Project.ProgramId,
                apj.Project.StartDate, apj.Project.EndDate, apj.Project.Status))
            .Distinct()
            .ToListAsync(cancellationToken);
    }

    public async Task<ProjectDto> CreateAsync(CreateProjectRequest request, CancellationToken cancellationToken = default)
    {
        var project = new Project
        {
            ProjectName = request.ProjectName,
            ProgramId = request.ProgramId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Comments = request.Comments,
            Status = "Active",
            CreatedOn = DateTime.UtcNow
        };

        project = await projectRepository.AddAsync(project, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new ProjectDto(
            project.ProjectId, project.ProjectName, project.ProgramId,
            project.StartDate, project.EndDate, project.Status);
    }

    public async Task<ProjectDto> UpdateAsync(int projectId, UpdateProjectRequest request, CancellationToken cancellationToken = default)
    {
        var project = await projectRepository.GetByIdAsync(projectId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Project), projectId);

        if (request.ProjectName is not null) project.ProjectName = request.ProjectName;
        if (request.StartDate is not null) project.StartDate = request.StartDate;
        if (request.EndDate is not null) project.EndDate = request.EndDate;
        if (request.Status is not null) project.Status = request.Status;
        if (request.Comments is not null) project.Comments = request.Comments;

        await projectRepository.UpdateAsync(project, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new ProjectDto(
            project.ProjectId, project.ProjectName, project.ProgramId,
            project.StartDate, project.EndDate, project.Status);
    }

    public async Task DeleteAsync(int projectId, CancellationToken cancellationToken = default)
    {
        var project = await projectRepository.GetByIdAsync(projectId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Project), projectId);

        await projectRepository.DeleteAsync(project, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<ProjectSummaryDto> GetProjectSummaryAsync(int projectId, CancellationToken cancellationToken = default)
    {
        var project = await projectRepository.Query()
            .AsNoTracking()
            .Where(p => p.ProjectId == projectId)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Project), projectId);

        var subjects = await assignProjectRepository.Query()
            .AsNoTracking()
            .Where(ap => ap.ProjectId == projectId)
            .SelectMany(ap => ap.AssignSubjects)
            .Select(asub => new SubjectDto(
                asub.Subject!.SubjectId, asub.Subject.Salutation,
                asub.Subject.FirstName, asub.Subject.LastName,
                asub.Subject.Email, asub.Subject.Organization, asub.Subject.Designation,
                asub.Subject.ClientId, asub.Subject.City, asub.Subject.Country,
                asub.Subject.CreatedOn, asub.Subject.FinancialMission, asub.Subject.UserType))
            .ToListAsync(cancellationToken);

        return new ProjectSummaryDto(project.ProjectId, project.ProjectName, subjects);
    }
}
