using System;
using System.Collections.Generic;
using DataAccess.Layer.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Layer.DataContext;

public partial class NewRepairDbQaContext : DbContext
{
    public NewRepairDbQaContext()
    {
    }

    public NewRepairDbQaContext(DbContextOptions<NewRepairDbQaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAP-TUN-6V8PH33\\SQLEXPRESS;database=NewRepair-db-qa;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;Connect timeout=17000");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AI");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClId);

            entity.ToTable("Clients", "mdm");

            entity.HasIndex(e => e.ClCreatedDate, "IX_mdm_Clients_CreatedDate");

            entity.Property(e => e.ClId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CL_Id");
            entity.Property(e => e.ClCreatedBy)
                .HasMaxLength(250)
                .HasColumnName("CL_CreatedBy");
            entity.Property(e => e.ClCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CL_CreatedDate");
            entity.Property(e => e.ClCultureCodePreferredLanguage)
                .HasMaxLength(10)
                .HasColumnName("CL_CultureCodePreferredLanguage");
            entity.Property(e => e.ClCurrencyCode)
                .HasMaxLength(3)
                .HasColumnName("CL_CurrencyCode");
            entity.Property(e => e.ClExternalCode)
                .HasMaxLength(10)
                .HasColumnName("CL_ExternalCode");
            entity.Property(e => e.ClInactive).HasColumnName("CL_Inactive");
            entity.Property(e => e.ClLastModifiedBy)
                .HasMaxLength(250)
                .HasColumnName("CL_LastModifiedBy");
            entity.Property(e => e.ClLastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("CL_LastModifiedDate");
            entity.Property(e => e.ClTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("CL_TimeStamp");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
