namespace PharmaFlow.Web.ViewModels;

public class UserViewModel
{
    public required Guid ID { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required UserRoleViewModel Role { get; init; }

    public required string Email { get; init; }

    public required string PasswordHash { get; init; }

    public required UserStateViewModel State { get; init; }
}
