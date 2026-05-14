using System.ComponentModel.DataAnnotations;

namespace APBD_C07.DTOs;

public record CreatePCsRequest(
    [MaxLength(50)] string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
    );