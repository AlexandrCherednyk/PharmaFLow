namespace ComputerShop.DataAccess.Repositories;

public class ManufacturerRepository : IManufacturerRepository
{
    private readonly PharmaFlowDbContext _db;

    public ManufacturerRepository(PharmaFlowDbContext db)
    {
        _db = db;
    }

    public Task AddManufacturer(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductManufacturerPersistence>> GetManufacturerList()
    {
        throw new NotImplementedException();
    }

    //public async Task AddManufacturer(string name)
    //{
    //    string procedure = StoredProcedures.ADD_MANUFACTURER;

    //    using (MySqlConnection connection = new(DbContext.CONNECTION))
    //    {
    //        await connection.OpenAsync();

    //        MySqlCommand command = new(procedure, connection);

    //        command.CommandType = CommandType.StoredProcedure;

    //        MySqlParameter NameParam = new()
    //        {
    //            ParameterName = "name",
    //            Value = name
    //        };

    //        command.Parameters.Add(NameParam);

    //        await command.ExecuteScalarAsync();
    //    }
    //}

    //public async Task<List<ProductManufacturerPersistence>> GetManufacturerList()
    //{
    //    List<ProductManufacturerPersistence> manufacturers = new();

    //    string procedure = StoredProcedures.GET_MANUFACTURER;

    //    using (MySqlConnection connection = new(DbContext.CONNECTION))
    //    {
    //        await connection.OpenAsync();

    //        MySqlCommand command = new(procedure, connection);

    //        command.CommandType = CommandType.StoredProcedure;

    //        MySqlDataReader reader = command.ExecuteReader();

    //        if (reader.HasRows)
    //        {
    //            while (reader.Read())
    //            {
    //                int ID = (int)reader.GetValue(0);
    //                string name = (string)reader.GetValue(1);

    //                ProductManufacturerPersistence manufacturer = new()
    //                {
    //                    ID = ID,
    //                    Name = name,
    //                };

    //                manufacturers.Add(manufacturer);
    //            }
    //        }

    //        reader.Close();
    //    }

    //    return manufacturers;
    //}
}
