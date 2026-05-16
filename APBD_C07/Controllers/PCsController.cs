using APBD_C07.DTOs;
using APBD_C07.Exceptions;
using APBD_C07.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_C07.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController(IPCsService service) : ControllerBase

{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        Console.WriteLine("metoda 1");
        var pcs = await service.GetAllAsync(cancellationToken);
        return Ok(pcs);
    }

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetComponents(int id, CancellationToken cancellationToken)
    {
        try
        {
            var components = await service.GetByIdAsync(id, cancellationToken);
            return Ok(components);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message }); 
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePCsRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); 
        }

        var createdPc = await service.AddAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetComponents), new { id = createdPc.Id }, createdPc);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePCsRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await service.UpdateAsync(id, request, cancellationToken);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            await service.DeleteAsync(id, cancellationToken);
            return NoContent();
            
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}