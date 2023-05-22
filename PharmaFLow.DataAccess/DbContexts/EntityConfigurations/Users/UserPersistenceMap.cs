namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Users;

internal class UserPersistenceMap : IEntityTypeConfiguration<UserPersistence>
{
    public void Configure(EntityTypeBuilder<UserPersistence> builder)
    {
        builder.ToTable("user");

        builder.HasKey(u => u.ID);

        builder.Property(u => u.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("user_id");

        builder.Property(u => u.FirstName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .HasMaxLength(1024)
            .IsRequired();

        builder.Property(u => u.Role)
            .HasConversion<int>();

        builder.Property(u => u.State)
            .HasConversion<int>();
    }
}
