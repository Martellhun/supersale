using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SuperSale.Models;

namespace SuperSale.Data
{
    public partial class ServiceDBContext : DbContext
    {
        public ServiceDBContext()
        {
        }

        public ServiceDBContext(DbContextOptions<ServiceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarParts> CarParts { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DiBrands> DiBrands { get; set; }
        public virtual DbSet<DiPartTypes> DiPartTypes { get; set; }
        public virtual DbSet<DiServicePackTypes> DiServicePackTypes { get; set; }
        public virtual DbSet<DiTypes> DiTypes { get; set; }
        public virtual DbSet<Orderitems> Orderitems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Parts> Parts { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<ServicePacks> ServicePacks { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Warranties> Warranties { get; set; }

        // Unable to generate entity type for table 'dbo.WarrantyTypes'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.di_Statuses'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=HUBPA-PF1J39E0;Database=ServiceDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarParts>(entity =>
            {
                entity.HasKey(e => e.ConnectionId);

                entity.Property(e => e.ConnectionId).HasColumnName("ConnectionID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.CarId);

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.Generation)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Company)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DiBrands>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.ToTable("di_Brands");

                entity.Property(e => e.BrandId)
                    .HasColumnName("BrandID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DiPartTypes>(entity =>
            {
                entity.HasKey(e => e.PartTypeId);

                entity.ToTable("di_PartTypes");

                entity.Property(e => e.PartTypeId).HasColumnName("PartTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DiServicePackTypes>(entity =>
            {
                entity.HasKey(e => e.ServicePackTypeId);

                entity.ToTable("di_ServicePackTypes");

                entity.Property(e => e.ServicePackTypeId)
                    .HasColumnName("ServicePackTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DiTypes>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("di_Types");

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orderitems>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PartId).HasColumnName("PartID");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.RecordedAt).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(13, 2)");
            });

            modelBuilder.Entity<Parts>(entity =>
            {
                entity.HasKey(e => e.PartId);

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(13, 2)");

                entity.Property(e => e.Service).HasColumnName("SERVICE");

                entity.Property(e => e.Um)
                    .IsRequired()
                    .HasColumnName("UM")
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.HasKey(e => e.RecipeId);

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

            });

            modelBuilder.Entity<ServicePacks>(entity =>
            {
                entity.HasKey(e => e.ServicePackId);

                entity.Property(e => e.ServicePackId).HasColumnName("ServicePackID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.ServicePackTypeId).HasColumnName("ServicePackTypeID");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Streettype)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Warranties>(entity =>
            {
                entity.HasKey(e => e.WarrantyId);

                entity.Property(e => e.WarrantyId).HasColumnName("WarrantyID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.PartTypeId).HasColumnName("PartTypeID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });
        }
    }
}
