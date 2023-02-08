using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GroceryShopMiniProjNew.Models
{
    public partial class ProductDBContext : DbContext
    {
        public ProductDBContext()
        {
        }

        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GroceryProduct> GroceryProducts { get; set; } = null!;
        public virtual DbSet<LoginPage> LoginPages { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=WJLP-1495; Initial Catalog=ProductDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__GroceryP__9834FB9AEF8DD18A");

                entity.ToTable("GroceryProduct");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_ID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");

                entity.Property(e => e.ProductQuantityKg).HasColumnName("Product_Quantity_KG");
            });

            modelBuilder.Entity<LoginPage>(entity =>
            {
                entity.ToTable("loginPage");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Pasword)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("pasword");

                entity.Property(e => e.Username)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Adress)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Name");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                //entity.HasOne(d => d.Product)
                //    .WithMany(p => p.Sales)
                //    .HasForeignKey(d => d.ProductId)
                //    .HasConstraintName("FK__Sales__Product_I__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
