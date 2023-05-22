using Microsoft.EntityFrameworkCore.Design;

namespace PharmaFLow.DataAccess.DbContexts;

public class PharmaFlowDbContextFactory : IDesignTimeDbContextFactory<PharmaFlowDbContext>
{
    public PharmaFlowDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PharmaFlowDbContext>();
        optionsBuilder.UseSqlServer("Server=pharmaflow.database.windows.net;Database=PharmaFlow;User Id=alexandr.cherednyk;Password=pa33word!");

        return new PharmaFlowDbContext(optionsBuilder.Options);
    }
}
