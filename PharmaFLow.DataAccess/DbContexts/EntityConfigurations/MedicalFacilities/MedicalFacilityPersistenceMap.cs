namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.MedicalFacilities;

internal class MedicalFacilityPersistenceMap : IEntityTypeConfiguration<MedicalFacilityPersistence>
{
    public void Configure(EntityTypeBuilder<MedicalFacilityPersistence> builder)
    {
        builder.ToTable("medical_facility");

        builder.HasKey(m => m.ID);

        builder.Property(m => m.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("medical_facility_id");

        builder.Property(m => m.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(m => m.Address)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasOne(p => p.Type)
            .WithMany(t => t.MedicalFacilities)
            .HasForeignKey(p => p.TypeID)
            .IsRequired(true)
            .HasConstraintName("fk_medical_facility_type");

        builder.Property(m => m.State)
            .HasConversion<int>();
    }
}
