namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Pharmacies;

internal class PharmacyPersistenceMap : IEntityTypeConfiguration<PharmacyPersistence>
{
    public void Configure(EntityTypeBuilder<PharmacyPersistence> builder)
    {
        builder.ToTable("pharmacy");

        builder.HasKey(p => p.ID);

        builder.Property(p => p.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("pharmacy_id");

        builder.Property(p => p.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.State)
            .HasConversion<int>();
    }
}
