using APBD_C07.DTOs;
using APBD_C07.Models;

namespace APBD_C07.Services;

public interface IPCsService
{
    Task<IEnumerable<PCsDetails>> GetAllAsync(CancellationToken cancellationToken);
    Task<ComponentDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PCsDetails> AddAsync(CreatePCsRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdatePCsRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);

}