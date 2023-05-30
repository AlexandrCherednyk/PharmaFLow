namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Reports;

internal class InputReportPersistenceMap : IEntityTypeConfiguration<InputReportPersistence>
{
    public void Configure(EntityTypeBuilder<InputReportPersistence> builder)
    {
        builder.ToTable("input_report");

        builder.HasKey(ir => ir.ID);

        builder.Property(ir => ir.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("input_report_id");

        builder.Property(ir => ir.Count)
            .IsRequired();

        builder.Property(ir => ir.TotalPrice)
            .HasColumnType("decimal(18,4)")
            .IsRequired();

        builder.Property(ir => ir.Count)
            .HasColumnType("decimal(18,4)")
            .IsRequired();

        builder.Property(ir => ir.CreatedOn)
            .IsRequired();

        builder.HasOne(ir => ir.Product)
            .WithMany()
            .HasForeignKey(ir => ir.ProductID)
            .IsRequired()
            .HasConstraintName("fk_input_report_product");

        builder.HasOne(ir => ir.User)
            .WithMany(u => u.InputReports)
            .HasForeignKey(ir => ir.UserID)
            .IsRequired()
            .HasConstraintName("fk_input_report_user");
    }
}
