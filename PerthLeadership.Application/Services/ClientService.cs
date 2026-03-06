using Microsoft.EntityFrameworkCore;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;
using PerthLeadership.Domain.Entities.Client;
using PerthLeadership.Domain.Exceptions;
using PerthLeadership.Domain.Interfaces;

namespace PerthLeadership.Application.Services;

public sealed class ClientService(
    IRepository<ClientOrganization> clientRepository,
    IRepository<OverAllUser> overAllUserRepository,
    IUnitOfWork unitOfWork) : IClientService
{
    public async Task<ClientDto?> GetByIdAsync(int clientId, CancellationToken cancellationToken = default)
    {
        return await clientRepository.Query()
            .AsNoTracking()
            .Where(c => c.ClientId == clientId)
            .Select(c => new ClientDto(
                c.ClientId, c.ClientCode, c.CompanyName,
                c.City, c.Country, c.Status, c.CreatedOn, c.Archieve))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ClientDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await clientRepository.Query()
            .AsNoTracking()
            .OrderByDescending(c => c.CreatedOn)
            .Select(c => new ClientDto(
                c.ClientId, c.ClientCode, c.CompanyName,
                c.City, c.Country, c.Status, c.CreatedOn, c.Archieve))
            .ToListAsync(cancellationToken);
    }

    public async Task<ClientDto> CreateAsync(CreateClientRequest request, CancellationToken cancellationToken = default)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var overAllUser = new OverAllUser
            {
                UserName = request.CompanyName,
                Role = "Client",
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };
            overAllUser = await overAllUserRepository.AddAsync(overAllUser, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            var client = new ClientOrganization
            {
                ClientCode = request.ClientCode,
                CompanyName = request.CompanyName,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                State = request.State,
                Zip = request.Zip,
                Country = request.Country,
                Website = request.Website,
                PhoneNo1 = request.PhoneNo1,
                PhoneNo2 = request.PhoneNo2,
                Status = request.Status,
                Comments = request.Comments,
                BillingAddress1 = request.BillingAddress1,
                BillingAddress2 = request.BillingAddress2,
                BillingCity = request.BillingCity,
                BillingState = request.BillingState,
                BillingZip = request.BillingZip,
                BillingCountry = request.BillingCountry,
                IsSameBilling = request.IsSameBilling,
                ShippingAddress1 = request.ShippingAddress1,
                ShippingAddress2 = request.ShippingAddress2,
                ShippingCity = request.ShippingCity,
                ShippingState = request.ShippingState,
                ShippingZip = request.ShippingZip,
                ShippingCountry = request.ShippingCountry,
                OverAllUserId = overAllUser.OverallUserId,
                CreatedOn = DateTime.UtcNow
            };
            client = await clientRepository.AddAsync(client, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await unitOfWork.CommitTransactionAsync(cancellationToken);

            return new ClientDto(
                client.ClientId, client.ClientCode, client.CompanyName,
                client.City, client.Country, client.Status, client.CreatedOn, client.Archieve);
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task<ClientDto> UpdateAsync(int clientId, UpdateClientRequest request, CancellationToken cancellationToken = default)
    {
        var client = await clientRepository.GetByIdAsync(clientId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(ClientOrganization), clientId);

        if (request.ClientCode is not null) client.ClientCode = request.ClientCode;
        if (request.CompanyName is not null) client.CompanyName = request.CompanyName;
        if (request.Address1 is not null) client.Address1 = request.Address1;
        if (request.Address2 is not null) client.Address2 = request.Address2;
        if (request.City is not null) client.City = request.City;
        if (request.State is not null) client.State = request.State;
        if (request.Zip is not null) client.Zip = request.Zip;
        if (request.Country is not null) client.Country = request.Country;
        if (request.Website is not null) client.Website = request.Website;
        if (request.PhoneNo1 is not null) client.PhoneNo1 = request.PhoneNo1;
        if (request.PhoneNo2 is not null) client.PhoneNo2 = request.PhoneNo2;
        if (request.Status is not null) client.Status = request.Status;
        if (request.Comments is not null) client.Comments = request.Comments;
        if (request.IsArchived is not null) client.Archieve = request.IsArchived;

        await clientRepository.UpdateAsync(client, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new ClientDto(
            client.ClientId, client.ClientCode, client.CompanyName,
            client.City, client.Country, client.Status, client.CreatedOn, client.Archieve);
    }

    public async Task DeleteAsync(int clientId, CancellationToken cancellationToken = default)
    {
        var client = await clientRepository.GetByIdAsync(clientId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(ClientOrganization), clientId);

        await clientRepository.DeleteAsync(client, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<ClientDetailDto?> GetDetailAsync(int clientId, CancellationToken cancellationToken = default)
    {
        return await clientRepository.Query()
            .AsNoTracking()
            .Where(c => c.ClientId == clientId)
            .Select(c => new ClientDetailDto(
                c.ClientId, c.ClientCode, c.CompanyName,
                c.Address1, c.Address2, c.City, c.State,
                c.Zip, c.Country, c.Website, c.PhoneNo1,
                c.Status, c.Comments, c.CreatedOn,
                c.ClientContacts.Select(cc => new ClientContactDto(
                    cc.ContactId, cc.Salutation, cc.FirstName, cc.LastName,
                    cc.Email, cc.Phone1, cc.City, cc.Country)).ToList(),
                c.AssignPrograms.Select(ap => new ProgramDto(
                    ap.TrainingProgram!.ProgramId, ap.TrainingProgram.ProgramName, ap.TrainingProgram.Description,
                    ap.TrainingProgram.CreatedDate, ap.TrainingProgram.Status)).ToList()))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
