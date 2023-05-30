namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Contacts;

internal class ContactPersistenceMap : IEntityTypeConfiguration<ContactPersistence>
{
    public void Configure(EntityTypeBuilder<ContactPersistence> builder)
    {
        builder.ToTable("contacts");

        builder.HasKey(c => c.ID);

        builder.Property(c => c.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("contact_id");

        builder.Property(c => c.FirstName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.Phone)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(c => c.State)
            .HasConversion<int>();
    }
}
