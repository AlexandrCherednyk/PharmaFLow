namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Products;

internal class ProductCharacteristicPersistenceMap : IEntityTypeConfiguration<ProductCharacteristicPersistence>
{
    public void Configure(EntityTypeBuilder<ProductCharacteristicPersistence> builder)
    {
        builder.ToTable("product_characteristic");

        builder.HasKey(pc => pc.ID);

        builder.Property(pc => pc.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("product_characteristic_id");

        builder.Property(pc => pc.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(pc => pc.Value)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(pc => pc.State)
            .HasConversion<int>();
    }
}
