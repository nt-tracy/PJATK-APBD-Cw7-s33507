namespace APBD_C07.DTOs;

public record UpdatePCsRequest(
    string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);