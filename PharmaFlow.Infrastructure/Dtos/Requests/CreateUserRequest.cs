namespace PharmaFlow.Infrastructure.Dtos.Requests;

public record CreateUserRequest
{
    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public required UserRoleDto Role { get; init; }

    public required string PasswordHash { get; init; }
}
