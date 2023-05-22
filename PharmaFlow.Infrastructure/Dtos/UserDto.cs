namespace PharmaFlow.Infrastructure.Dtos;

public record UserDto
{
    public Guid ID { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required UserRoleDto Role { get; init; }

    public required string Email { get; init; }

    public required string PasswordHash { get; init; }

    public required UserStateDto State { get; init; }
}
