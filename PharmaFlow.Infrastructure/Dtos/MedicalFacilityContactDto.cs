namespace PharmaFlow.Infrastructure.Dtos;

public record MedicalFacilityContactDto
{
    public Guid ID { get; set; }

    public required ContactDto Cotnact { get; set; }

    public required MedicalFacilityContactPositionDto Position { get; set; }
}
