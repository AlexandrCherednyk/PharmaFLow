namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Products;

internal class ProductPersistenceMap : IEntityTypeConfiguration<ProductPersistence>
{
    public void Configure(EntityTypeBuilder<ProductPersistence> builder)
    {
        builder.ToTable("product");

        builder.HasKey(p => p.ID);

        builder.Property(p => p.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("product_id");

        builder.Property(p => p.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,4)")
            .IsRequired();

        builder.Property(p => p.Count)
            .HasColumnType("decimal(18,4)")
            .IsRequired();

        builder.Property(p => p.PathToFile)
            .HasMaxLength(1025);

        builder.Property(p => p.State)
            .HasConversion<int>();

        builder.HasOne(p => p.Type)
            .WithMany(t => t.Products)
            .HasForeignKey(p => p.TypeID)
            .IsRequired(true)
            .HasConstraintName("fk_product_product_type");

        builder.HasOne(p => p.Manufacturer)
            .WithMany(m => m.Products)
            .HasForeignKey(p => p.ManufacturerID)
            .IsRequired(true)
            .HasConstraintName("fk_product_product_manufacturer");

        builder
            .HasMany(p => p.Characteristics)
            .WithMany(c => c.Products);

        builder.ToTable(p =>
            p.HasCheckConstraint("price", "price > 0")
            .HasName("ck_product_price"));

        builder.ToTable(p =>
            p.HasCheckConstraint("count", "count > 0")
            .HasName("ck_product_count"));
    }
}
