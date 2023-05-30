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

        builder.Property(or => or.ConfirmedOn)
            .IsRequired(false);

        builder.Property(c => c.State)
            .HasConversion<int>();

        builder.HasOne(or => or.Product)
            .WithMany()
            .HasForeignKey(or => or.ProductID)
            .IsRequired()
            .HasConstraintName("fk_output_report_product");

        builder.HasOne(or => or.UserCreator)
            .WithMany()
            .HasForeignKey(or => or.UserCreatorID)
            .IsRequired()
            .HasConstraintName("fk_output_report_user_creator");

        builder.HasOne(or => or.StaffTarget)
            .WithMany()
            .HasForeignKey(or => or.StaffTargetID)
            .IsRequired()
            .HasConstraintName("fk_output_report_staff_target");

        builder.HasOne(or => or.UserConfirmator)
            .WithMany()
            .HasForeignKey(or => or.UserConfirmatorID)
            .IsRequired(false)
            .HasConstraintName("fk_output_report_user_confirmator");
    }
}
