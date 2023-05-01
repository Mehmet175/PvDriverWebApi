using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PvDriver.Utils;

#nullable disable

namespace PvDriver.Ef
{
    public partial class DRIVERSContext : DbContext
    {
        public DRIVERSContext()
        {
        }

        public DRIVERSContext(DbContextOptions<DRIVERSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<DefaultParameter> DefaultParameters { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceAddress> DeviceAddresses { get; set; }
        public virtual DbSet<DeviceParameter> DeviceParameters { get; set; }
        public virtual DbSet<DeviceUser> DeviceUsers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<GsmOperator> GsmOperators { get; set; }
        public virtual DbSet<ModelType> ModelTypes { get; set; }
        public virtual DbSet<PackageType> PackageTypes { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportLog> ReportLogs { get; set; }
        public virtual DbSet<ShortMode> ShortModes { get; set; }
        public virtual DbSet<TimedWork> TimedWorks { get; set; }
        public virtual DbSet<UnidentifiedDevice> UnidentifiedDevices { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Weather> Weathers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppConstants.SqlConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.TopCompanyNavigation)
                    .WithMany(p => p.InverseTopCompanyNavigation)
                    .HasForeignKey(d => d.TopCompany)
                    .HasConstraintName("FK_Companies_Companies");
            });

            modelBuilder.Entity<DefaultParameter>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Parameter).HasMaxLength(50);

                entity.HasOne(d => d.ModelType)
                    .WithMany(p => p.DefaultParameters)
                    .HasForeignKey(d => d.ModelTypeId)
                    .HasConstraintName("FK_DefaultParameters_ModelType");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device");

                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Address1).HasMaxLength(8);

                entity.Property(e => e.Address2).HasMaxLength(8);

                entity.Property(e => e.Address3).HasMaxLength(8);

                entity.Property(e => e.Address4).HasMaxLength(8);

                entity.Property(e => e.Address5).HasMaxLength(8);

                entity.Property(e => e.Address6).HasMaxLength(8);

                entity.Property(e => e.Address7).HasMaxLength(8);

                entity.Property(e => e.CardWarrantyExpiryDate).HasColumnType("date");

                entity.Property(e => e.DeviceKw).HasMaxLength(50);

                entity.Property(e => e.DeviceWarranty)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GsmFinishDate).HasColumnType("date");

                entity.Property(e => e.GsmNo).HasMaxLength(50);

                entity.Property(e => e.InstallationDate).HasColumnType("date");

                entity.Property(e => e.InstallationDistrict).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastWorkingStatusDateTime).HasColumnType("datetime");

                entity.Property(e => e.MotorkW).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SerialNo).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Device_Companies");

                entity.HasOne(d => d.GsmOperator)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.GsmOperatorId)
                    .HasConstraintName("FK_Device_GsmOperator");

                entity.HasOne(d => d.ModelType)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.ModelTypeId)
                    .HasConstraintName("FK_Device_ModelType");

                entity.HasOne(d => d.PackageType)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.PackageTypeId)
                    .HasConstraintName("FK_Device_PackageType");
            });

            modelBuilder.Entity<DeviceAddress>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.LastValue).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ProcessingTime).HasColumnType("date");

                entity.Property(e => e.SendValue).HasMaxLength(50);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceAddresses)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK_DeviceAddresses_Device");
            });

            modelBuilder.Entity<DeviceParameter>(entity =>
            {
                entity.Property(e => e.LastValue).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Parameter).HasMaxLength(50);

                entity.Property(e => e.ProcessingTime).HasColumnType("date");

                entity.Property(e => e.SendValue).HasMaxLength(50);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceParameters)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK_DeviceParameters_Device");
            });

            modelBuilder.Entity<DeviceUser>(entity =>
            {
                entity.ToTable("DeviceUser");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceUsers)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK_DeviceId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DeviceUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserId");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<GsmOperator>(entity =>
            {
                entity.ToTable("GsmOperator");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ModelType>(entity =>
            {
                entity.ToTable("ModelType");

                entity.Property(e => e.Address1).HasMaxLength(8);

                entity.Property(e => e.Address2).HasMaxLength(8);

                entity.Property(e => e.Address3).HasMaxLength(8);

                entity.Property(e => e.Address4).HasMaxLength(8);

                entity.Property(e => e.Address5).HasMaxLength(8);

                entity.Property(e => e.Address6).HasMaxLength(8);

                entity.Property(e => e.Address7).HasMaxLength(8);

                entity.Property(e => e.Dividing1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Dividing2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Dividing3).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Dividing4).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Dividing5).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Dividing6).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Dividing7).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Logo).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<PackageType>(entity =>
            {
                entity.ToTable("PackageType");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Value1).HasMaxLength(50);

                entity.Property(e => e.Value2).HasMaxLength(50);

                entity.Property(e => e.Value3).HasMaxLength(50);

                entity.Property(e => e.Value4).HasMaxLength(50);

                entity.Property(e => e.Value5).HasMaxLength(50);

                entity.Property(e => e.Value6).HasMaxLength(50);

                entity.Property(e => e.Value7).HasMaxLength(50);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_Device");
            });

            modelBuilder.Entity<ReportLog>(entity =>
            {
                entity.ToTable("ReportLog");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Value1).HasMaxLength(50);

                entity.Property(e => e.Value2).HasMaxLength(50);

                entity.Property(e => e.Value3).HasMaxLength(50);

                entity.Property(e => e.Value4).HasMaxLength(50);

                entity.Property(e => e.Value5).HasMaxLength(50);

                entity.Property(e => e.Value6).HasMaxLength(50);

                entity.Property(e => e.Value7).HasMaxLength(50);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.ReportLogs)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportLog_Device");
            });

            modelBuilder.Entity<ShortMode>(entity =>
            {
                entity.ToTable("ShortMode");
            });

            modelBuilder.Entity<TimedWork>(entity =>
            {
                entity.ToTable("TimedWork");

                entity.Property(e => e.FinishDay).HasMaxLength(15);

                entity.Property(e => e.StartDay).HasMaxLength(15);
            });

            modelBuilder.Entity<UnidentifiedDevice>(entity =>
            {
                entity.Property(e => e.CreateDateTime).HasColumnType("date");

                entity.Property(e => e.DeviceSerialNo).HasMaxLength(50);

                entity.Property(e => e.PackageType).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Users_Companies");
            });

            modelBuilder.Entity<Weather>(entity =>
            {
                entity.ToTable("Weather");

                entity.Property(e => e.Day).HasColumnType("date");

                entity.Property(e => e.DayName).HasMaxLength(50);

                entity.Property(e => e.Degree).HasMaxLength(20);

                entity.Property(e => e.Humidity).HasMaxLength(20);

                entity.Property(e => e.Image).HasMaxLength(150);

                entity.Property(e => e.Max).HasMaxLength(20);

                entity.Property(e => e.Min).HasMaxLength(20);

                entity.Property(e => e.Night).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
