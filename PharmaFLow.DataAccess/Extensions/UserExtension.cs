namespace PharmaFLow.DataAccess.Extensions;

internal static class UserExtension
{
    public static UserRolePersistence ToUserRolePersistence(this UserRoleDto role)
    {
        return role switch
        {
            UserRoleDto.Admin => UserRolePersistence.Admin,
            UserRoleDto.Manager => UserRolePersistence.Manager,
            UserRoleDto.Pharmacist => UserRolePersistence.Pharmacist,
            _ => throw new ArgumentException($"Invalid {nameof(role)}: {role}", nameof(role)),
        };
    }

    public static UserRoleDto ToUserRoleDto(this UserRolePersistence role)
    {
        return role switch
        {
            UserRolePersistence.Admin => UserRoleDto.Admin,
            UserRolePersistence.Manager => UserRoleDto.Manager,
            UserRolePersistence.Pharmacist => UserRoleDto.Pharmacist,
            _ => throw new ArgumentException($"Invalid {nameof(role)}: {role}", nameof(role)),
        };
    }

    public static UserStatePersistence ToUserStatePersistence(this UserStateDto state)
    {
        return state switch
        {
            UserStateDto.Active => UserStatePersistence.Active,
            UserStateDto.Removed => UserStatePersistence.Removed,
            _ => throw new ArgumentException($"Invalid {nameof(state)}: {state}", nameof(state)),
        };
    }

    public static UserStateDto ToUserStateDto(this UserStatePersistence state)
    {
        return state switch
        {
            UserStatePersistence.Active => UserStateDto.Active,
            UserStatePersistence.Removed => UserStateDto.Removed,
            _ => throw new ArgumentException($"Invalid {nameof(state)}: {state}", nameof(state)),
        };
    }

    public static UserPersistence ToUserPersistence(this UserDto user)
    {
        return new()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            Role = user.Role.ToUserRolePersistence(),
            State = user.State.ToUserStatePersistence(),
        };
    }

    public static List<UserDto> ToUserDtoList(this List<UserPersistence> userList)
    {
        return userList.ConvertAll(u => u.ToUserDto());
    }

    public static UserDto ToUserDto(this UserPersistence user)
    {
        return new()
        {
            ID = user.ID,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            Role = user.Role.ToUserRoleDto(),
            State = user.State.ToUserStateDto(),
        };
    }
}
