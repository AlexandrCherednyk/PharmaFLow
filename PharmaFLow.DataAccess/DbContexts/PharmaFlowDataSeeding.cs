using PharmaFlow.Utils;

namespace PharmaFLow.DataAccess.DbContexts;

internal static class PharmaFlowDataSeeding
{
    public static IList<UserPersistence> GetUsers()
    {
        SecurePasswordHasher hasher = new();

        return new List<UserPersistence>
        {
            new UserPersistence
            {
                FirstName = "Alexandr",
                LastName = "Cherednyk",
                Email = "admin@mail.com",
                Role = UserRolePersistence.Admin,
                PasswordHash = hasher.HashToString("password!"),
            },
            new UserPersistence
            {
                FirstName = "Ryan",
                LastName = "Gosling",
                Email = "manager@mail.com",
                Role = UserRolePersistence.Manager,
                PasswordHash = hasher.HashToString("password!"),
            },
            new UserPersistence
            {
                FirstName = "matt",
                LastName = "Johnson",
                Email = "pharmacist@mail.com",
                Role = UserRolePersistence.Pharmacist,
                PasswordHash = hasher.HashToString("password!"),
            },
        };
    }
}
