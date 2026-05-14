namespace APBD_C07.DTOs;

public record PCsDetails
(
    int Id,
    string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);