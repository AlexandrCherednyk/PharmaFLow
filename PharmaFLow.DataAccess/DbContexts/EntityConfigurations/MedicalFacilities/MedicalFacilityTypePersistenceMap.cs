namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.MedicalFacilities;

public class MedicalFacilityTypePersistenceMap : IEntityTypeConfiguration<MedicalFacilityTypePersistence>
{
    public void Configure(EntityTypeBuilder<MedicalFacilityTypePersistence> builder)
    {
        builder.ToTable("medical_facility_type");

        builder.HasKey(mt => mt.ID);

        builder.Property(mt => mt.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("medical_facility_type_id");

        builder.Property(m => m.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(m => m.State)
            .HasConversion<int>();
    }
}
