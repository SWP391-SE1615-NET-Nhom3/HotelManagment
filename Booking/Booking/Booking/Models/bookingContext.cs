using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Booking.Models
{
    public partial class bookingContext : DbContext
    {
        public bookingContext()
        {
        }

        public bookingContext(DbContextOptions<bookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<CategoryHomestay> CategoryHomestays { get; set; } = null!;
        public virtual DbSet<HomeStay> HomeStays { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=booking;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("ntext")
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<CategoryHomestay>(entity =>
            {
                entity.ToTable("CategoryHomestay");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("ntext")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<HomeStay>(entity =>
            {
                entity.ToTable("HomeStay");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("ntext")
                    .HasColumnName("address");

                entity.Property(e => e.Bathroom).HasColumnName("bathroom");

                entity.Property(e => e.Bedroom).HasColumnName("bedroom");

                entity.Property(e => e.CateId).HasColumnName("cate_id");

                entity.Property(e => e.Detail)
                    .HasColumnType("ntext")
                    .HasColumnName("detail");

                entity.Property(e => e.Image)
                    .HasColumnType("ntext")
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasColumnType("ntext")
                    .HasColumnName("name");

                entity.Property(e => e.Owner).HasColumnName("owner");

                entity.Property(e => e.PriceOneNight).HasColumnName("priceOneNight");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.HomeStays)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK__HomeStay__cate_i__2A4B4B5E");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.HomeStays)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK__HomeStay__owner__29572725");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Checkin)
                    .HasColumnType("date")
                    .HasColumnName("checkin");

                entity.Property(e => e.Checkout)
                    .HasColumnType("date")
                    .HasColumnName("checkout");

                entity.Property(e => e.HomestayId).HasColumnName("homestay_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserBook).HasColumnName("user_book");

                entity.HasOne(d => d.Homestay)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.HomestayId)
                    .HasConstraintName("FK__Orders__homestay__2D27B809");

                entity.HasOne(d => d.UserBookNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserBook)
                    .HasConstraintName("FK__Orders__user_boo__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
