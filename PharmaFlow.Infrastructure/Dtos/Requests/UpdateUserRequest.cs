namespace PharmaFlow.Infrastructure.Dtos.Requests;

public record UpdateUserRequest
{
    public Guid ID { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required UserRoleDto Role { get; init; }
}
