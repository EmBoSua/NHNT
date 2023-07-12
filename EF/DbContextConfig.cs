using Microsoft.EntityFrameworkCore;
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
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("tbl_user");
                e.HasKey(u => u.Id);
                e.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
                e.Property(u => u.UserName).HasColumnName("username").HasMaxLength(100).IsRequired();
                e.HasIndex(u => u.UserName).IsUnique();
                e.Property(u => u.Email).HasColumnName("email").HasMaxLength(150).IsRequired();
                e.HasIndex(u => u.Email).IsUnique();
                e.Property(u => u.Password).HasColumnName("password").HasMaxLength(255).IsRequired();
                e.HasMany(u => u.UserRoles).WithOne(ur => ur.User).HasForeignKey(ur => ur.UserId);
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
        }
    }
}