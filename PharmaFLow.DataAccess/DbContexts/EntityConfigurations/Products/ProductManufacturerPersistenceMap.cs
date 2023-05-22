namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Products;

internal class ProductManufacturerPersistenceMap : IEntityTypeConfiguration<ProductManufacturerPersistence>
{
    public void Configure(EntityTypeBuilder<ProductManufacturerPersistence> builder)
    {
        builder.ToTable("product_manufacturer");

        builder.HasKey(pm => pm.ID);

        builder.Property(pm => pm.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("product_manufacturer_id");

        builder.Property(pm => pm.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(pm => pm.State)
            .HasConversion<int>();
    }
}
