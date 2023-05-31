namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Meetings;

internal class MeetPersistenceMap : IEntityTypeConfiguration<MeetPersistence>
{
    public void Configure(EntityTypeBuilder<MeetPersistence> builder)
    {
        builder.ToTable("meetings");

        builder.HasKey(c => c.ID);

        builder.Property(c => c.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("meet_id");

        builder.Property(c => c.State)
            .HasConversion<int>();

        builder.HasOne(m => m.User)
            .WithMany()
            .HasForeignKey(m => m.UserID)
            .IsRequired(true)
            .HasConstraintName("fk_meet_user");

        builder.HasOne(m => m.StaffTarget)
            .WithMany()
            .HasForeignKey(m => m.StaffTargetID)
            .IsRequired(true)
            .HasConstraintName("fk_meet_medical_facility_contact");
    }
}
