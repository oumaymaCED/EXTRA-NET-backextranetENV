using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class NewRepairDbContext : DbContext
{
    public NewRepairDbContext()
    {
    }

    public NewRepairDbContext(DbContextOptions<NewRepairDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }

    public virtual DbSet<PurchaseInvoiceLine> PurchaseInvoiceLines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9CJJV5K\\SQLEXPRESS;Database=NewRepair-db-qa-data;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;Connect timeout=1200");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AI");

        modelBuilder.Entity<PurchaseInvoice>(entity =>
        {
            entity.HasKey(e => e.PurchaseInvoiceNumber);

            entity.ToTable("PurchaseInvoice");

            entity.Property(e => e.PurchaseInvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.DossierNumber).HasMaxLength(50);
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PurchaseInvoiceLine>(entity =>
        {
            entity.Property(e => e.PurchaseInvoiceLineId).HasColumnName("PurchaseInvoiceLineID");
            entity.Property(e => e.Discount)
                .HasMaxLength(50)
                .HasColumnName("discount");
            entity.Property(e => e.GrossAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("grossAmount");
            entity.Property(e => e.NetAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("netAmount");
            entity.Property(e => e.PurchaseInvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TaxAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("taxAmount");
            entity.Property(e => e.TaxRate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("taxRate");
            entity.Property(e => e.TotalDiscount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalDiscount");
            entity.Property(e => e.TotalGrossAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalGrossAmount");
            entity.Property(e => e.TotalNetAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalNetAmount");
            entity.Property(e => e.TotalTaxAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalTaxAmount");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("unitPrice");
            entity.Property(e => e.WorkingOrdernumber).HasMaxLength(50);

            entity.HasOne(d => d.PurchaseInvoiceNumberNavigation).WithMany(p => p.PurchaseInvoiceLines)
                .HasForeignKey(d => d.PurchaseInvoiceNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseInvoiceLines_PurchaseInvoice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
