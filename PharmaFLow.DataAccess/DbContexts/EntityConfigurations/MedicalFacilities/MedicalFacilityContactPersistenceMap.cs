namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.MedicalFacilities;

internal class MedicalFacilityContactPersistenceMap : IEntityTypeConfiguration<MedicalFacilityContactPersistence>
{
    public void Configure(EntityTypeBuilder<MedicalFacilityContactPersistence> builder)
    {
        builder.ToTable("medical_facility_contact");

        builder.HasKey(mc => mc.ID);

        builder.Property(mc => mc.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("medical_facility_contact_id");

        builder.HasOne(mc => mc.Position)
            .WithMany(t => t.Staff)
            .HasForeignKey(mc => mc.PositionID)
            .IsRequired(true)
            .HasConstraintName("fk_medical_facility_contact_type");

        builder.HasOne(mc => mc.Contact)
            .WithMany(c => c.MedicalFacilityContacts)
            .HasForeignKey(mc => mc.ContactID)
            .IsRequired(true)
            .HasConstraintName("fk_medical_facility_contact_contact");

        builder.HasOne(mc => mc.MedicalFacility)
            .WithMany(m => m.Staff)
            .HasForeignKey(mc => mc.MedicalFacilityID)
            .IsRequired(true)
            .HasConstraintName("fk_medical_facility_contact_medical_facility");

        builder.Property(m => m.State)
            .HasConversion<int>();
    }
}
