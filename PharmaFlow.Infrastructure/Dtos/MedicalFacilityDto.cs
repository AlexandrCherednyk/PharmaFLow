namespace PharmaFlow.Infrastructure.Dtos;

public record MedicalFacilityDto
{
    public Guid ID { get; set; }

    public required string Name { get; set; }

    public required string Address { get; set; }

    public required MedicalFacilityTypeDto Type { get; set; }

    public List<MedicalFacilityContactDto> Staff { get; set; } = new();
}
