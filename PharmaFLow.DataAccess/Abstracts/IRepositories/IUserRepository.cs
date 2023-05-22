using PharmaFlow.Infrastructure.Dtos.Requests;

namespace PharmaFLow.DataAccess.Abstracts.IRepositories;

public interface IUserRepository
{
    Task<List<UserDto>> GetUserListAsync();

    Task<UserDto> GetUserByEmailAsync(string email);

    Task AddUserAsync(CreateUserRequest request);

    Task UpdateUserAsync(UpdateUserRequest request);

    Task UpdateUserEmailAsync(Guid userID, string email);

    Task UpdateUserPasswordAsync(Guid userID, string passwordHash);

    Task RemoveUserByIDAsync(Guid userID);
}
