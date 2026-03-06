using Microsoft.EntityFrameworkCore;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;
using PerthLeadership.Domain.Entities.Client;
using PerthLeadership.Domain.Exceptions;
using PerthLeadership.Domain.Interfaces;

namespace PerthLeadership.Application.Services;

public sealed class SubjectService(
    IRepository<Subject> subjectRepository,
    IRepository<OverAllUser> overAllUserRepository,
    IUnitOfWork unitOfWork) : ISubjectService
{
    public async Task<SubjectDto?> GetByIdAsync(int subjectId, CancellationToken cancellationToken = default)
    {
        return await subjectRepository.Query()
            .AsNoTracking()
            .Where(s => s.SubjectId == subjectId)
            .Select(s => new SubjectDto(
                s.SubjectId, s.Salutation, s.FirstName, s.LastName,
                s.Email, s.Organization, s.Designation,
                s.ClientId, s.City, s.Country, s.CreatedOn,
                s.FinancialMission, s.UserType))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<SubjectDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await subjectRepository.Query()
            .AsNoTracking()
            .Where(s => s.Email == email)
            .Select(s => new SubjectDto(
                s.SubjectId, s.Salutation, s.FirstName, s.LastName,
                s.Email, s.Organization, s.Designation,
                s.ClientId, s.City, s.Country, s.CreatedOn,
                s.FinancialMission, s.UserType))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<SubjectDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await subjectRepository.Query()
            .AsNoTracking()
            .OrderByDescending(s => s.CreatedOn)
            .Select(s => new SubjectDto(
                s.SubjectId, s.Salutation, s.FirstName, s.LastName,
                s.Email, s.Organization, s.Designation,
                s.ClientId, s.City, s.Country, s.CreatedOn,
                s.FinancialMission, s.UserType))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<SubjectDto>> GetByClientIdAsync(int clientId, CancellationToken cancellationToken = default)
    {
        return await subjectRepository.Query()
            .AsNoTracking()
            .Where(s => s.ClientId == clientId)
            .OrderByDescending(s => s.CreatedOn)
            .Select(s => new SubjectDto(
                s.SubjectId, s.Salutation, s.FirstName, s.LastName,
                s.Email, s.Organization, s.Designation,
                s.ClientId, s.City, s.Country, s.CreatedOn,
                s.FinancialMission, s.UserType))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<SubjectDto>> GetUnassignedAsync(CancellationToken cancellationToken = default)
    {
        return await subjectRepository.Query()
            .AsNoTracking()
            .Where(s => !s.AssignSubjects.Any())
            .OrderByDescending(s => s.CreatedOn)
            .Select(s => new SubjectDto(
                s.SubjectId, s.Salutation, s.FirstName, s.LastName,
                s.Email, s.Organization, s.Designation,
                s.ClientId, s.City, s.Country, s.CreatedOn,
                s.FinancialMission, s.UserType))
            .ToListAsync(cancellationToken);
    }

    public async Task<SubjectDto> CreateAsync(CreateSubjectRequest request, CancellationToken cancellationToken = default)
    {
        var existingSubject = await subjectRepository.Query()
            .AsNoTracking()
            .AnyAsync(s => s.Email == request.Email, cancellationToken);

        if (existingSubject)
            throw new BusinessRuleViolationException($"A subject with email '{request.Email}' already exists.");

        await unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var overAllUser = new OverAllUser
            {
                UserName = request.Email,
                Password = request.Password ?? string.Empty,
                Email = request.Email,
                Role = "Subject",
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };
            overAllUser = await overAllUserRepository.AddAsync(overAllUser, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            var subject = new Subject
            {
                Salutation = request.Salutation,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Organization = request.Organization,
                Designation = request.Designation,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                State = request.State?.ToString(),
                Zip = request.Zip,
                Country = request.Country,
                Phone1 = request.Phone1,
                Phone2 = request.Phone2,
                ClientId = request.ClientId,
                OverallUserId = overAllUser.OverallUserId,
                CreatedOn = DateTime.UtcNow,
                UserType = request.UserType,
                LanguageId = request.LanguageId
            };
            subject = await subjectRepository.AddAsync(subject, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await unitOfWork.CommitTransactionAsync(cancellationToken);

            return new SubjectDto(
                subject.SubjectId, subject.Salutation, subject.FirstName, subject.LastName,
                subject.Email, subject.Organization, subject.Designation,
                subject.ClientId, subject.City, subject.Country, subject.CreatedOn,
                subject.FinancialMission, subject.UserType);
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task<SubjectDto> UpdateAsync(int subjectId, UpdateSubjectRequest request, CancellationToken cancellationToken = default)
    {
        var subject = await subjectRepository.GetByIdAsync(subjectId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Subject), subjectId);

        if (request.Salutation is not null) subject.Salutation = request.Salutation;
        if (request.FirstName is not null) subject.FirstName = request.FirstName;
        if (request.LastName is not null) subject.LastName = request.LastName;
        if (request.Email is not null) subject.Email = request.Email;
        if (request.Organization is not null) subject.Organization = request.Organization;
        if (request.Designation is not null) subject.Designation = request.Designation;
        if (request.Address1 is not null) subject.Address1 = request.Address1;
        if (request.Address2 is not null) subject.Address2 = request.Address2;
        if (request.City is not null) subject.City = request.City;
        if (request.State is not null) subject.State = request.State.Value.ToString();
        if (request.Zip is not null) subject.Zip = request.Zip;
        if (request.Country is not null) subject.Country = request.Country;
        if (request.Phone1 is not null) subject.Phone1 = request.Phone1;
        if (request.Phone2 is not null) subject.Phone2 = request.Phone2;
        if (request.FinancialMission is not null) subject.FinancialMission = request.FinancialMission;
        if (request.UserType is not null) subject.UserType = request.UserType;
        if (request.LanguageId is not null) subject.LanguageId = request.LanguageId;

        await subjectRepository.UpdateAsync(subject, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new SubjectDto(
            subject.SubjectId, subject.Salutation, subject.FirstName, subject.LastName,
            subject.Email, subject.Organization, subject.Designation,
            subject.ClientId, subject.City, subject.Country, subject.CreatedOn,
            subject.FinancialMission, subject.UserType);
    }

    public async Task DeleteAsync(int subjectId, CancellationToken cancellationToken = default)
    {
        var subject = await subjectRepository.GetByIdAsync(subjectId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Subject), subjectId);

        await subjectRepository.DeleteAsync(subject, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<SubjectDto?> ValidateLoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        return await subjectRepository.Query()
            .AsNoTracking()
            .Join(
                overAllUserRepository.Query().AsNoTracking(),
                s => s.OverallUserId,
                u => u.OverallUserId,
                (s, u) => new { Subject = s, User = u })
            .Where(x => x.Subject.Email == email
                && x.User.Password == password
                && x.User.IsActive == true)
            .Select(x => new SubjectDto(
                x.Subject.SubjectId, x.Subject.Salutation, x.Subject.FirstName, x.Subject.LastName,
                x.Subject.Email, x.Subject.Organization, x.Subject.Designation,
                x.Subject.ClientId, x.Subject.City, x.Subject.Country, x.Subject.CreatedOn,
                x.Subject.FinancialMission, x.Subject.UserType))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
