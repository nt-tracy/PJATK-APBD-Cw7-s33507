using APBD_C07.DTOs;
using APBD_C07.Exceptions;
using APBD_C07.Infrastructure;
using APBD_C07.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_C07.Services;

public class PCsService(DatabaseContext  ctx) : IPCsService
{

    public async Task<IEnumerable<PCsDetails>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PCsDetails(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
            )).ToListAsync(cancellationToken);
    }

    public async Task<ComponentDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
                   .Where(e => e.Id == id)
                   .Select(pc => new ComponentDetailsResponse(
                       pc.Id,
                       pc.Name,
                       pc.Weight,
                       pc.Warranty,
                       pc.CreatedAt,
                       pc.Stock,
                       pc.PcComponents.Select(pcc => new PCComponentDto(
                           pcc.Amount,
                           new SingleComponentDto(
                               pcc.ComponentCode,
                               pcc.PCs.Name,
                               pcc.Components.Description,
                               new ManufacturerDto(
                                   pcc.Components.ComponentManufacturers.Id,
                                   pcc.Components.ComponentManufacturers.Abbreviation,
                                   pcc.Components.ComponentManufacturers.FullName,
                                   pcc.Components.ComponentManufacturers.FoundationDate.ToString("yyyy-MM-dd")
                               ),
                               new TypeDto(
                                   pcc.Components.ComponentTypes.Id,
                                   pcc.Components.ComponentTypes.Abbreviation,
                                   pcc.Components.ComponentTypes.Name
                               )
                           )
                       ))
                   )).FirstOrDefaultAsync(cancellationToken)
               ?? throw new NotFoundException($"PC with id {id} not found");
    }

    public async Task<PCsDetails> AddAsync(CreatePCsRequest request, CancellationToken cancellationToken)
    {
        var pc = new PCs
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);

        return new PCsDetails(pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
            );


    }

    public async Task UpdateAsync(int id, UpdatePCsRequest request, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs
            .Where(pc => pc.Id == id)
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(pc => pc.Name, request.Name)
                    .SetProperty(pc => pc.Weight, request.Weight)
                    .SetProperty(pc => pc.Warranty, request.Warranty)
                    .SetProperty(pc => pc.CreatedAt, request.CreatedAt)
                    .SetProperty(pc => pc.Stock, request.Stock),
                cancellationToken
            );

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }
    
    
    

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
        
        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }    
    }
}