﻿using BookingSystem.ReadPersistence.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.ReadPersistence
{
    public partial class BookingReadContext : DbContext
    {
        public BookingReadContext()
        {
        }

        public BookingReadContext(DbContextOptions<BookingReadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingExtraService> BookingExtraServices { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<ExtraService> ExtraServices { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelImage> HotelImages { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomsImage> RoomsImages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 4)");

            });

            modelBuilder.Entity<BookingExtraService>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.ExtraServiceId });

            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<ExtraService>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

            });

            modelBuilder.Entity<HotelImage>(entity =>
            {
                entity.HasKey(e => new { e.HotelId, e.ImageId });
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<RoomsImage>(entity =>
            {
                entity.HasKey(e => new { e.RoomId, e.ImageId });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });
        }
    }
}
