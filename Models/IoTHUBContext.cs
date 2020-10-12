using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IoTHUB_v1._0.Models
{
    public partial class IoTHUBContext : DbContext
    {
        public IoTHUBContext()
        {
        }

        public IoTHUBContext(DbContextOptions<IoTHUBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ComplaintypeTbl> ComplaintypeTbl { get; set; }
        public virtual DbSet<ContactformTbl> ContactformTbl { get; set; }
        public virtual DbSet<DeviceTbl> DeviceTbl { get; set; }
        public virtual DbSet<DevicecategoryTbl> DevicecategoryTbl { get; set; }
        public virtual DbSet<DevicepermId> DevicepermId { get; set; }
        public virtual DbSet<FeedbackTbl> FeedbackTbl { get; set; }
        public virtual DbSet<HelpSupportTbl> HelpSupportTbl { get; set; }
        public virtual DbSet<RegistereddevicesTbl> RegistereddevicesTbl { get; set; }
        public virtual DbSet<RequestserviceTbl> RequestserviceTbl { get; set; }
        public virtual DbSet<RfidTbl> RfidTbl { get; set; }
        public virtual DbSet<RoleTbl> RoleTbl { get; set; }
        public virtual DbSet<ServiceTbl> ServiceTbl { get; set; }
        public virtual DbSet<UserTbl> UserTbl { get; set; }
        public virtual DbSet<UserattendanceTbl> UserattendanceTbl { get; set; }
        public virtual DbSet<UsertimetrackerTbl> UsertimetrackerTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
     //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7T6QIOI;Database=IoTHUB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplaintypeTbl>(entity =>
            {
                entity.HasKey(e => e.ComptypeId);

                entity.ToTable("complaintype_tbl");

                entity.Property(e => e.ComptypeId).HasColumnName("comptype_id");

                entity.Property(e => e.CompType)
                    .IsRequired()
                    .HasColumnName("comp_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ContactformTbl>(entity =>
            {
                entity.HasKey(e => e.CtId);

                entity.ToTable("contactform_tbl");

                entity.Property(e => e.CtId).HasColumnName("ct_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phoneno)
                    .IsRequired()
                    .HasColumnName("phoneno")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeviceTbl>(entity =>
            {
                entity.HasKey(e => e.DeviceId);

                entity.ToTable("device_tbl");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DevicecatId).HasColumnName("devicecat_id");

                entity.Property(e => e.Devicename)
                    .IsRequired()
                    .HasColumnName("devicename")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Updateddate)
                    .HasColumnName("updateddate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Devicecat)
                    .WithMany(p => p.DeviceTbl)
                    .HasForeignKey(d => d.DevicecatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_device_tbl_devicecategory_tbl");
            });

            modelBuilder.Entity<DevicecategoryTbl>(entity =>
            {
                entity.HasKey(e => e.DevicecatId);

                entity.ToTable("devicecategory_tbl");

                entity.Property(e => e.DevicecatId).HasColumnName("devicecat_id");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Devicecatname)
                    .IsRequired()
                    .HasColumnName("devicecatname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DevicepermId>(entity =>
            {
                entity.HasKey(e => e.DevicepermId1);

                entity.ToTable("deviceperm_id");

                entity.Property(e => e.DevicepermId1).HasColumnName("deviceperm_id");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.Updateddate)
                    .HasColumnName("updateddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DevicepermId)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_deviceperm_id_device_tbl");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DevicepermId)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_deviceperm_id_user_tbl");
            });

            modelBuilder.Entity<FeedbackTbl>(entity =>
            {
                entity.ToTable("feedback_tbl");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Feedback)
                    .IsRequired()
                    .HasColumnName("feedback")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FeedbackTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_feedback_tbl_user_tbl");
            });

            modelBuilder.Entity<HelpSupportTbl>(entity =>
            {
                entity.HasKey(e => e.HelpId);

                entity.ToTable("help&support_tbl");

                entity.Property(e => e.HelpId).HasColumnName("help_id");

                entity.Property(e => e.ComptypeId).HasColumnName("comptype_id");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Comptype)
                    .WithMany(p => p.HelpSupportTbl)
                    .HasForeignKey(d => d.ComptypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_help&support_tbl_complaintype_tbl");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HelpSupportTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_help&support_tbl_user_tbl");
            });

            modelBuilder.Entity<RegistereddevicesTbl>(entity =>
            {
                entity.HasKey(e => e.RegdevId);

                entity.ToTable("registereddevices_tbl");

                entity.Property(e => e.RegdevId).HasColumnName("regdev_id");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.Updateddate)
                    .HasColumnName("updateddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.RegistereddevicesTbl)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registereddevices_tbl_device_tbl");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RegistereddevicesTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registereddevices_tbl_user_tbl");
            });

            modelBuilder.Entity<RequestserviceTbl>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("requestservice_tbl");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Requestdescription)
                    .IsRequired()
                    .HasColumnName("requestdescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.RequestserviceTbl)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_requestservice_tbl_service_tbl");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RequestserviceTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_requestservice_tbl_user_tbl");
            });

            modelBuilder.Entity<RfidTbl>(entity =>
            {
                entity.HasKey(e => e.RfidId);

                entity.ToTable("rfid_tbl");

                entity.Property(e => e.RfidId).HasColumnName("rfid_id");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Rfid).HasColumnName("rfid");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RfidTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_rfid_tbl_user_tbl");
            });

            modelBuilder.Entity<RoleTbl>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("role_tbl");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasColumnName("rolename")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServiceTbl>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("service_tbl");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Servicename)
                    .IsRequired()
                    .HasColumnName("servicename")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTbl>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("user_tbl");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Companyemail)
                    .IsRequired()
                    .HasColumnName("companyemail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Isparent).HasColumnName("isparent");

                entity.Property(e => e.Mediapath)
                    .IsRequired()
                    .HasColumnName("mediapath")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("phone_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserTbl)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_tbl_role_tbl");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.UserTbl)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_tbl_service_tbl");
            });

            modelBuilder.Entity<UserattendanceTbl>(entity =>
            {
                entity.HasKey(e => e.AttendanceId);

                entity.ToTable("userattendance_tbl");

                entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");

                entity.Property(e => e.Attendancedate)
                    .HasColumnName("attendancedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RfidId).HasColumnName("rfid_id");

                entity.HasOne(d => d.Rfid)
                    .WithMany(p => p.UserattendanceTbl)
                    .HasForeignKey(d => d.RfidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userattendance_tbl_rfid_tbl");
            });

            modelBuilder.Entity<UsertimetrackerTbl>(entity =>
            {
                entity.HasKey(e => e.UttId);

                entity.ToTable("usertimetracker_tbl");

                entity.Property(e => e.UttId).HasColumnName("utt_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.RfidId).HasColumnName("rfid_id");

                entity.Property(e => e.Workinghours).HasColumnName("workinghours");

                entity.HasOne(d => d.Rfid)
                    .WithMany(p => p.UsertimetrackerTbl)
                    .HasForeignKey(d => d.RfidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usertimetracker_tbl_rfid_tbl");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
