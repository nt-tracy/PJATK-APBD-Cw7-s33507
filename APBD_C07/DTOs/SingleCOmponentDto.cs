namespace APBD_C07.DTOs;

public record SingleComponentDto(
    string Code,
    string Name,
    string Description,
    ManufacturerDto Manufacturer,
    TypeDto Type
);