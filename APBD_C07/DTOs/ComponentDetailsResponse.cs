namespace APBD_C07.DTOs;

public record ComponentDetailsResponse(
    
    int Id,
    string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PCComponentDto> Components
);