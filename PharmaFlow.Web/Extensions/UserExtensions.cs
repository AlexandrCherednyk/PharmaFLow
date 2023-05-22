using PharmaFlow.Web.Areas.Admin.ViewModels;
using PharmaFLow.DataAccess.Persistences;

namespace PharmaFlow.Web.Extensions;

internal static class UserExtensions
{
    public static UserRoleViewModel ToUserRoleViewModel(this UserRoleDto role)
    {
        return role switch
        {
            UserRoleDto.Admin => UserRoleViewModel.Admin,
            UserRoleDto.Manager => UserRoleViewModel.Manager,
            UserRoleDto.Pharmacist => UserRoleViewModel.Pharmacist,
            _ => throw new ArgumentException($"Invalid {nameof(role)}: {role}", nameof(role)),
        };
    }

    public static UserRoleDto ToUserRoleDto(this UserRoleViewModel role)
    {
        return role switch
        {
            UserRoleViewModel.Admin => UserRoleDto.Admin,
            UserRoleViewModel.Manager => UserRoleDto.Manager,
            UserRoleViewModel.Pharmacist => UserRoleDto.Pharmacist,
            _ => throw new ArgumentException($"Invalid {nameof(role)}: {role}", nameof(role)),
        };
    }

    public static UserStateViewModel ToUserStateViewModel(this UserStateDto state)
    {
        return state switch
        {
            UserStateDto.Active => UserStateViewModel.Active,
            UserStateDto.Removed => UserStateViewModel.Removed,
            _ => throw new ArgumentException($"Invalid {nameof(state)}: {state}", nameof(state)),
        };
    }

    public static List<UserViewModel> ToUserViewModelList(this List<UserDto> userList)
    {
        return userList.ConvertAll(u => u.ToUserViewModel());
    }

    public static UserViewModel ToUserViewModel(this UserDto user)
    {
        return new()
        {
            ID = user.ID,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            Role = user.Role.ToUserRoleViewModel(),
            State = user.State.ToUserStateViewModel(),
        };
    }

    public static DetailedUserViewModel ToDetailedUserViewModel(this UserDto user)
    {
        return new()
        {
            ID = user.ID,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role.ToUserRoleViewModel(),
        };
    }
}
