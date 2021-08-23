using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eCommerceAPI.Models
{
    public partial class eCommercedbContext : DbContext
    {
        public eCommercedbContext()
        {
        }

        public eCommercedbContext(DbContextOptions<eCommercedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Pin).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Image).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Total).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
