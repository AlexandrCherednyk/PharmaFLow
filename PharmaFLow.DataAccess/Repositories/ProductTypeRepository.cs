namespace ComputerShop.DataAccess.Repositories;

public class ProductTypeRepository : IProductTypeRepository
{
    //public async Task AddProductType(string name)
    //{
    //    string procedure = StoredProcedures.ADD_TYPE;

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

    //public async Task<List<ProductTypePersistence>> GetProductTypeList()
    //{
    //    List<ProductTypePersistence> types = new();

    //    string procedure = StoredProcedures.GET_TYPE;

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

    //                ProductTypePersistence type = new()
    //                {
    //                    ID = ID,
    //                    Name = name,
    //                };

    //                types.Add(type);
    //            }
    //        }

    //        reader.Close();
    //    }

    //    return types;
    //}
    public Task AddProductType(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductTypePersistence>> GetProductTypeList()
    {
        throw new NotImplementedException();
    }
}
