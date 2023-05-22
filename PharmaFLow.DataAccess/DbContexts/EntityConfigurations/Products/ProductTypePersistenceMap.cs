namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Products;

internal class ProductTypePersistenceMap : IEntityTypeConfiguration<ProductTypePersistence>
{
    public void Configure(EntityTypeBuilder<ProductTypePersistence> builder)
    {
        builder.ToTable("product_type");

        builder.HasKey(pt => pt.ID);

        builder.Property(pt => pt.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("product_type_id");

        builder.Property(pt => pt.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(pt => pt.State)
            .HasConversion<int>();
    }
}
