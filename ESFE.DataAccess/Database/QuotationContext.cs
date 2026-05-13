using System;
using System.Collections.Generic;
using ESFE.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESFE.DataAccess;

public partial class QuotationContext : DbContext
{
    public QuotationContext()
    {
    }

    public QuotationContext(DbContextOptions<QuotationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Quotation> Quotations { get; set; }

    public virtual DbSet<QuotationDetail> QuotationDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MODERNIZACION;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__brands__5E5A8E27A66C8F60");

            entity.ToTable("brands");

            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("brand_name");
            entity.Property(e => e.BrandStatus)
                .HasDefaultValue((byte)1)
                .HasColumnName("brand_status");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF5A83E5CF9");

            entity.ToTable("products");

            entity.HasIndex(e => e.ProductCode, "UQ__products__AE1A8CC4926D5428").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.PriceUnitSale)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_unit_sale");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_code");
            entity.Property(e => e.ProductDescription)
                .HasColumnType("text")
                .HasColumnName("product_description");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductStatus)
                .HasDefaultValue((byte)1)
                .HasColumnName("product_status");
            entity.Property(e => e.Stock)
                .HasDefaultValue(0)
                .HasColumnName("stock");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__products__brand___59063A47");
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.HasKey(e => e.QuotationId).HasName("PK__quotatio__7841D7DB77168F12");

            entity.ToTable("quotations");

            entity.HasIndex(e => e.QuotationNumber, "UQ__quotatio__5C85B685C11B3FDE").IsUnique();

            entity.Property(e => e.QuotationId).HasColumnName("quotation_id");
            entity.Property(e => e.ClientName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("client_name");
            entity.Property(e => e.QuotationNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("quotation_number");
            entity.Property(e => e.QuotationRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("quotation_registration");
            entity.Property(e => e.QuotationStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("quotation_status");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Quotations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__quotation__user___5DCAEF64");
        });

        modelBuilder.Entity<QuotationDetail>(entity =>
        {
            entity.HasKey(e => e.QuotationDetailId).HasName("PK__quotatio__131ABC6063F52D2A");

            entity.ToTable("quotation_details");

            entity.Property(e => e.QuotationDetailId).HasColumnName("quotation_detail_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.QuotationId).HasColumnName("quotation_id");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.Product).WithMany(p => p.QuotationDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__quotation__produ__619B8048");

            entity.HasOne(d => d.Quotation).WithMany(p => p.QuotationDetails)
                .HasForeignKey(d => d.QuotationId)
                .HasConstraintName("FK__quotation__quota__60A75C0F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__roles__CF32E4432EDF2705");

            entity.ToTable("roles");

            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.RolName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol_name");
            entity.Property(e => e.RolStatus)
                .HasDefaultValue((byte)1)
                .HasColumnName("rol_status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FA84E3CED");

            entity.ToTable("users");

            entity.HasIndex(e => e.UserNickname, "UQ__users__E1E179E2C846EF22").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registration_date");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.UserNickname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_nickname");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_password");
            entity.Property(e => e.UserStatus)
                .HasDefaultValue((byte)1)
                .HasColumnName("user_status");

            entity.HasOne(d => d.Rol).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__users__rol_id__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
