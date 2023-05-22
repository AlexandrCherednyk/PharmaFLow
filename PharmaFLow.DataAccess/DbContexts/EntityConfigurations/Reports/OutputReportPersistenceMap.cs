namespace PharmaFLow.DataAccess.DbContexts.EntityConfigurations.Reports;
 
internal class OutputReportPersistenceMap : IEntityTypeConfiguration<OutputReportPersistence>
{
    public void Configure(EntityTypeBuilder<OutputReportPersistence> builder)
    {
        builder.ToTable("output_report");

        builder.HasKey(or => or.ID);

        builder.Property(or => or.ID)
            .ValueGeneratedOnAdd()
            .HasColumnName("output_report_id");

        builder.Property(or => or.Count)
            .HasColumnType("decimal(18,4)")
            .IsRequired();

        builder.Property(or => or.TotalPrice)
            .HasColumnType("decimal(18,4)")
            .IsRequired();

        builder.Property(or => or.CreatedOn)
            .IsRequired();

        builder.HasOne(or => or.Product)
            .WithMany()
            .HasForeignKey(or => or.ProductID)
            .IsRequired()
            .HasConstraintName("fk_output_report_product");

        builder.HasOne(or => or.User)
            .WithMany(u => u.OutputReports)
            .HasForeignKey(or => or.UserID)
            .IsRequired()
            .HasConstraintName("fk_output_report_user");

        builder.ToTable(p =>
            p.HasCheckConstraint("count", "count > 0")
            .HasName("ck_output_report_count"));

        builder.ToTable(p =>
            p.HasCheckConstraint("total_price", "total_price > 0")
            .HasName("ck_output_report_total_price"));
    }
}
