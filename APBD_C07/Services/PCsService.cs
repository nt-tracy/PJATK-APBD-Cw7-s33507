using APBD_C07.DTOs;
using APBD_C07.Infrastructure;

namespace APBD_C07.Services;

public class PCsService(DatabaseContext  ctx) : IPCsService
{

    public async Task<IEnumerable<PCsDetails>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ComponentDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PCsDetails> AddAsync(CreatedPCsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, UpdatePCsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}