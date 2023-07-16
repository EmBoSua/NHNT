using System;
using Microsoft.EntityFrameworkCore;
using NHNT.Constants;
using NHNT.Models;

namespace NHNT.EF
{
    public class DbContextConfig : DbContext
    {
        public DbContextConfig(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<DepartmentGroup> DepartmentGroups { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("tbl_user");
                e.HasKey(u => u.Id);
                e.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
                e.Property(u => u.Username).HasColumnName("username").HasMaxLength(100).IsRequired();
                e.HasIndex(u => u.Username).IsUnique();
                e.Property(u => u.Email).HasColumnName("email").HasMaxLength(150).IsRequired();
                e.HasIndex(u => u.Email).IsUnique();
                e.Property(u => u.Password).HasColumnName("password").HasMaxLength(255).IsRequired();
                e.HasMany(u => u.UserRoles).WithOne(ur => ur.User).HasForeignKey(ur => ur.UserId);
                e.Property(u => u.FullName).HasColumnName("full_name").HasMaxLength(255);
                e.HasIndex(u => u.Phone).IsUnique();
                e.Property(u => u.Phone).HasColumnName("phone").HasMaxLength(11);
                e.Property(u => u.Gender).HasColumnName("gender").HasConversion<int>().HasDefaultValue(Gender.OTHER);
                e.Property(u => u.Birthday).HasColumnName("birthday");
                e.Property(u => u.IsDisable).HasColumnName("is_disable").HasDefaultValue(0);
                e.Property(u => u.CreateAt).HasColumnName("create_at").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                e.Property(u => u.UpdateAt).HasColumnName("update_at").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
                e.HasMany(u => u.Departments).WithOne(d => d.User).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("tbl_role");
                e.HasKey(r => r.Id);
                e.Property(r => r.Id).HasColumnName("id").ValueGeneratedOnAdd();
                e.Property(r => r.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
                e.HasIndex(r => r.Name).IsUnique();
                e.Property(r => r.Discription).HasColumnName("discription").HasMaxLength(300);
                e.HasMany(r => r.UserRoles).WithOne(ur => ur.Role).HasForeignKey(ur => ur.RoleId);
            });

            modelBuilder.Entity<UserRole>(e =>
            {
                e.ToTable("tbl_user_role");
                e.HasKey(ur => new { ur.RoleId, ur.UserId });
                e.Property(ur => ur.UserId).HasColumnName("user_id");
                e.Property(ur => ur.RoleId).HasColumnName("role_id");
                e.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
                e.HasOne(ur => ur.Role).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.RoleId);
            });

            modelBuilder.Entity<RefreshToken>(e =>
            {
                e.ToTable("tbl_refresh_token");
                e.HasKey(rf => rf.Id);
                e.Property(rf => rf.Id).HasColumnName("id").ValueGeneratedOnAdd();
                e.Property(rf => rf.UserId).HasColumnName("user_id");
                e.HasOne(rf => rf.User).WithMany().HasForeignKey(rf => rf.UserId).IsRequired();
                e.Property(rf => rf.Value).HasColumnName("value").IsRequired().HasMaxLength(255);
                e.Property(rf => rf.JwtId).HasColumnName("jwt_id").IsRequired().HasMaxLength(255);
                e.Property(rf => rf.IsUsed).HasColumnName("is_used").HasDefaultValue(true);
                e.Property(rf => rf.IsRevoked).HasColumnName("is_revoked").HasDefaultValue(true);
                e.Property(rf => rf.IssuedAt).HasColumnName("issued_at").IsRequired();
                e.Property(rf => rf.ExpiredAt).HasColumnName("expired_at").IsRequired();
            });

            modelBuilder.Entity<DepartmentGroup>(e => {
                e.ToTable("tbl_department_group");
                e.HasKey(dg => dg.Id);
                e.Property(dg => dg.Id).HasColumnName("id").ValueGeneratedOnAdd();
                e.Property(dg => dg.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
                e.Property(dg => dg.Discription).HasColumnName("discription").HasMaxLength(300);
                e.HasMany(dg => dg.Departments).WithOne(d => d.Group).HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<Department>(e => {
                e.ToTable("department");
                e.HasKey(d => d.Id);
                e.Property(d => d.Id).HasColumnName("id");
                e.Property(d => d.Address).HasColumnName("address").HasMaxLength(200).IsRequired();
                e.Property(d => d.Price).HasColumnName("price").HasColumnType("decimal(12, 3)").HasConversion(p => Math.Round(p, 2), p => p).IsRequired();
                e.Property(d => d.PhoneNumber).HasColumnName("phone_number").HasMaxLength(11).IsRequired();
                e.Property(d => d.RoomAread).HasColumnName("room_aread").IsRequired().HasColumnType("decimal(3, 2)").HasConversion(ra => Math.Round(ra, 2), ra => ra);
                e.Property(d => d.Status).HasColumnName("status").HasConversion<int>().HasDefaultValue(DepartmentStatus.PENDING);
                e.Property(d => d.Discription).HasColumnName("discription").HasMaxLength(1000).IsRequired();
                e.Property(d => d.Latitude).HasColumnName("Latitude").HasPrecision(18, 6);
                e.Property(d => d.Longtide).HasColumnName("longtitude").HasPrecision(18, 6);
                e.Property(d => d.IsAvailable).HasColumnName("is_available").HasDefaultValue(true);
                e.Property(d => d.CreateAt).HasColumnName("create_at").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                e.Property(d => d.UpdateAt).HasColumnName("update_at").HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
                e.Property(d => d.UserId).HasColumnName("user_id");
                e.HasOne(d => d.User).WithMany(u => u.Departments).HasForeignKey(d => d.UserId).IsRequired();
                e.HasOne(d => d.Group).WithMany(dg => dg.Departments).HasForeignKey(d => d.GroupId).IsRequired();
                e.Property(d => d.GroupId).HasColumnName("group_id");
                e.HasMany(d => d.Images).WithOne(i => i.Department).HasForeignKey(i => i.DepartmentId);
            });

            modelBuilder.Entity<Image>(e => {
                e.ToTable("tbl_image");
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).HasColumnName("id");
                e.Property(i => i.Path).HasColumnName("path").HasMaxLength(150).IsRequired();
                e.Property(i => i.CreateAt).HasColumnName("create_at").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                e.Property(i => i.DepartmentId).HasColumnName("department_id");
                e.HasOne(i => i.Department).WithMany(d => d.Images).HasForeignKey(i => i.DepartmentId);
            });
        }
    }
}