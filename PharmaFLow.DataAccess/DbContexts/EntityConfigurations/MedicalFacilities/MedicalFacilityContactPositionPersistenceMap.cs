namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.MedicalFacilities;

public class MedicalFacilityContactPositionPersistenceMap : IEntityTypeConfiguration<MedicalFacilityContactPositionPersistence>
{
    public void Configure(EntityTypeBuilder<MedicalFacilityContactPositionPersistence> builder)
    {
        builder.ToTable("medical_facility_contact_position");

        builder.HasKey(mcp => mcp.ID);

        builder.Property(mcp => mcp.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("medical_facility_contact_position_id");

        builder.Property(m => m.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(m => m.State)
            .HasConversion<int>();
    }
}
