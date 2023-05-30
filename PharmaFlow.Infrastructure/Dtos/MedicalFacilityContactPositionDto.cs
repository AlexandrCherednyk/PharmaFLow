namespace PharmaFlow.Infrastructure.Dtos;

public record MedicalFacilityContactPositionDto
{
    public Guid ID { get; set; }

    public required string Name { get; set; }
}
