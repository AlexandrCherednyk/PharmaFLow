namespace PharmaFlow.Infrastructure.Dtos;

public record MedicalFacilityTypeDto
{
    public Guid ID { get; set; }

    public required string Name { get; set; }
}
