namespace PharmaFlow.Infrastructure.Dtos;

public record ContactDto
{
    public Guid ID { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; }

    public List<MedicalFacilityContactDto> MedicalFacilityContacts { get; set; } = new();
}
