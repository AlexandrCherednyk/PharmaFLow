using Microsoft.Extensions.Configuration;

namespace PharmaFLow.DataAccess.DbContexts;

public class PharmaFlowDbContext : DbContext
{
    private IConfiguration? Configuration { get; set; }

    public PharmaFlowDbContext(DbContextOptions<PharmaFlowDbContext> options) : base(options) { }

    public PharmaFlowDbContext(
        DbContextOptions<PharmaFlowDbContext> options,
        IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<UserPersistence> Users { get; set; }

    public DbSet<ProductCharacteristicPersistence> ProductCharacteristics { get; set; }

    public DbSet<ProductManufacturerPersistence> ProductManufacturers { get; set; }

    public DbSet<ProductTypePersistence> ProductTypes { get; set; }

    public DbSet<ProductPersistence> Products { get; set; }

    public DbSet<InputReportPersistence> InputReports { get; set; }

    public DbSet<OutputReportPersistence> OutputReports { get; set; }

    public DbSet<MedicalFacilityPersistence> MedicalFacilities { get; set; }

    public DbSet<MedicalFacilityTypePersistence> MedicalFacilityTypes { get; set; }

    public DbSet<MedicalFacilityContactPersistence> MedicalFacilityContacts { get; set; }

    public DbSet<MedicalFacilityContactPositionPersistence> MedicalFacilityContactPositions { get; set; }

    public DbSet<ContactPersistence> Contacts { get; set; }

    public void SeedUsers()
    {
        if (Users.Any()) return;

        IList<UserPersistence> users = PharmaFlowDataSeeding.GetUsers();

        Users.AddRange(users);
        SaveChanges();
    }

    public void SeedProducts()
    {
        if (Products.Any()) return;

        IList<ProductPersistence> products = PharmaFlowDataSeeding.GetProducts();
        Products.AddRange(products);
        SaveChanges();
    }

    public void SeedMedicalFacilities()
    {
        if (MedicalFacilities.Any()) return;

        IList<MedicalFacilityPersistence> medicalFacilities = PharmaFlowDataSeeding.GetMedicalFacilities();
        MedicalFacilities.AddRange(medicalFacilities);
        SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(Configuration!.GetConnectionString("SqlConnection"))
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
