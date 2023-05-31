namespace PharmaFlow.Infrastructure.Dtos;

public record MedicalFacilityContactDto
{
    public Guid ID { get; set; }

    public string Address { get; set; } = null!;

    public required ContactDto Cotnact { get; set; }

    public required MedicalFacilityContactPositionDto Position { get; set; }
}
