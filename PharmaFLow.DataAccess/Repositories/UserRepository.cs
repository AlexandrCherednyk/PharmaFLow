using Azure.Core;
using Microsoft.Data.SqlClient;
using PharmaFlow.Infrastructure.Dtos.Requests;
using PharmaFLow.DataAccess.Extensions;

namespace ComputerShop.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PharmaFlowDbContext _db;

    public UserRepository(PharmaFlowDbContext db)
    {
        _db = db;
    }

    public async Task<List<UserDto>> GetUserListAsync()
    {
        try
        {
            List<UserPersistence> users = await _db.Users
                .Where(u => u.State == UserStatePersistence.Active)
                .ToListAsync();

            return users.ToUserDtoList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException(Errors.InvalidArguments);
        }

        try
        {
            UserPersistence user = await _db.Users.FirstAsync(u =>
                u.Email == email
                && u.State == UserStatePersistence.Active);

            return user.ToUserDto();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw; 
        }
    }

    public async Task AddUserAsync(CreateUserRequest request)
    {
        try
        {
            if (await _db.Users.AnyAsync(u =>
                u.Email == request.Email
                && u.State == UserStatePersistence.Active))
            {
                throw new InvalidOperationException();
            }

            UserPersistence user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Role = request.Role.ToUserRolePersistence(),
                PasswordHash = request.PasswordHash,
            };

            _db.Users.Add(user);
            
            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateUserAsync(UpdateUserRequest request)
    {
        try
        {
            UserPersistence user = await _db.Users.FirstAsync(u =>
                u.ID == request.ID
                && u.State == UserStatePersistence.Active);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Role = request.Role.ToUserRolePersistence();

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateUserEmailAsync(Guid userID, string email)
    {
        try
        {
            if (await _db.Users.AnyAsync(u => u.Email == email))
            {
                throw new InvalidOperationException();
            }

            UserPersistence user = await _db.Users.FirstAsync(u =>
                u.ID == userID
                && u.State == UserStatePersistence.Active);

            user.Email = email;

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateUserPasswordAsync(Guid userID, string passwordHash)
    {
        try
        {
            UserPersistence user = await _db.Users.FirstAsync(u =>
                u.ID == userID
                && u.State == UserStatePersistence.Active);

            user.PasswordHash = passwordHash;

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task RemoveUserByIDAsync(Guid userID)
    {
        try
        {
            UserPersistence user = await _db.Users.FirstAsync(u =>
                u.ID == userID
                && u.State == UserStatePersistence.Active);

            if (user.Role == UserRolePersistence.Admin)
            {
                if (!(await _db.Users.AnyAsync(u =>
                    u.ID != userID
                    && u.Role == UserRolePersistence.Admin
                    && u.State == UserStatePersistence.Active)))
                {
                    throw new InvalidOperationException();
                }
            }

            user.State = UserStatePersistence.Removed;

            await _db.SaveChangesAsync();
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
