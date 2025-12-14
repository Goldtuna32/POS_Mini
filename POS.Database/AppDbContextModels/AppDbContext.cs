using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace POS.Database.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductCategoryTable> ProductCategoryTables { get; set; }

    public virtual DbSet<ProductTable> ProductTables { get; set; }

    public virtual DbSet<SaleDetailTable> SaleDetailTables { get; set; }

    public virtual DbSet<SaleTable> SaleTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UUEE2ME\\SA;Database=POS_Mini;User Id=sa;Password=17112006;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategoryTable>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK_ProductCategory");

            entity.ToTable("ProductCategoryTable");

            entity.Property(e => e.ProductCategoryCode).HasMaxLength(50);
            entity.Property(e => e.ProductCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductTable>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product");

            entity.ToTable("ProductTable");

            entity.Property(e => e.ProductCategoryCode).HasMaxLength(50);
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<SaleDetailTable>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId).HasName("PK_SaleDetail");

            entity.ToTable("SaleDetailTable");

            entity.Property(e => e.Price).HasMaxLength(50);
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.Quantity).HasMaxLength(50);
            entity.Property(e => e.VoucherNo).HasMaxLength(50);
        });

        modelBuilder.Entity<SaleTable>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK_Sale");

            entity.ToTable("SaleTable");

            entity.Property(e => e.SaleDate).HasMaxLength(50);
            entity.Property(e => e.SaleVoucherNo).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
