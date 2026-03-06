using Microsoft.EntityFrameworkCore;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;
using PerthLeadership.Domain.Entities.Client;
using PerthLeadership.Domain.Exceptions;
using PerthLeadership.Domain.Interfaces;

namespace PerthLeadership.Application.Services;

public sealed class ProgramService(
    IRepository<TrainingProgram> programRepository,
    IRepository<AssignProgram> assignProgramRepository,
    IUnitOfWork unitOfWork) : IProgramService
{
    public async Task<ProgramDto?> GetByIdAsync(int programId, CancellationToken cancellationToken = default)
    {
        return await programRepository.Query()
            .AsNoTracking()
            .Where(p => p.ProgramId == programId)
            .Select(p => new ProgramDto(
                p.ProgramId, p.ProgramName, p.Description,
                p.CreatedDate, p.Status))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ProgramDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await programRepository.Query()
            .AsNoTracking()
            .OrderByDescending(p => p.CreatedDate)
            .Select(p => new ProgramDto(
                p.ProgramId, p.ProgramName, p.Description,
                p.CreatedDate, p.Status))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ProgramDto>> GetByClientIdAsync(int clientId, CancellationToken cancellationToken = default)
    {
        return await assignProgramRepository.Query()
            .AsNoTracking()
            .Where(ap => ap.ClientId == clientId)
            .Select(ap => new ProgramDto(
                ap.TrainingProgram!.ProgramId, ap.TrainingProgram.ProgramName, ap.TrainingProgram.Description,
                ap.TrainingProgram.CreatedDate, ap.TrainingProgram.Status))
            .ToListAsync(cancellationToken);
    }

    public async Task<ProgramDto> CreateAsync(CreateProgramRequest request, CancellationToken cancellationToken = default)
    {
        var program = new TrainingProgram
        {
            ProgramName = request.ProgramName,
            Description = request.Description,
            CreatedDate = DateTime.UtcNow,
            Status = "Active"
        };

        program = await programRepository.AddAsync(program, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new ProgramDto(
            program.ProgramId, program.ProgramName, program.Description,
            program.CreatedDate, program.Status);
    }

    public async Task<ProgramDto> UpdateAsync(int programId, UpdateProgramRequest request, CancellationToken cancellationToken = default)
    {
        var program = await programRepository.GetByIdAsync(programId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(TrainingProgram), programId);

        if (request.ProgramName is not null) program.ProgramName = request.ProgramName;
        if (request.Description is not null) program.Description = request.Description;
        if (request.Status is not null) program.Status = request.Status;

        await programRepository.UpdateAsync(program, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new ProgramDto(
            program.ProgramId, program.ProgramName, program.Description,
            program.CreatedDate, program.Status);
    }

    public async Task DeleteAsync(int programId, CancellationToken cancellationToken = default)
    {
        var program = await programRepository.GetByIdAsync(programId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(TrainingProgram), programId);

        await programRepository.DeleteAsync(program, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
