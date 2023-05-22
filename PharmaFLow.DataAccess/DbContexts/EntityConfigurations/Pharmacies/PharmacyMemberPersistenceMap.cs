namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Pharmacies;

internal class PharmacyMemberPersistenceMap : IEntityTypeConfiguration<PharmacyMemberPersistence>
{
    public void Configure(EntityTypeBuilder<PharmacyMemberPersistence> builder)
    {
        builder.ToTable("pharmacy_member");

        builder.HasKey(pm => pm.ID);

        builder.Property(pm => pm.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("pharmacy_member_id");

        builder.Property(pm => pm.FirstName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(pm => pm.LastName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(pm => pm.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(pm => pm.Phone)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(pm => pm.State)
            .HasConversion<int>();

        builder.HasOne(pm => pm.Pharmacy)
            .WithMany(p => p.Members)
            .HasForeignKey(pm => pm.PharmacyID)
            .IsRequired(true)
            .HasConstraintName("fk_pharmacy_member_pharmacy");
    }
}
