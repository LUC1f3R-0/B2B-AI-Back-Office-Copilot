using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSPlatform.Domain.Entities;
using SaaSPlatform.Domain.Enums;

namespace SaaSPlatform.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
        .HasColumnName("id");

        builder.Property(x => x.UserUuid)
        .HasColumnName("user_uuid")
        .IsRequired();
        builder.HasIndex(x => x.UserUuid)
        .IsUnique();

        builder.Property(x => x.FullName)
        .HasColumnName("full_name")
        .HasMaxLength(150);
        
        builder.Property(x => x.Email)
        .HasColumnName("email")
        .HasMaxLength(255)
        .IsRequired();
        builder.HasIndex(x => x.Email)
        .IsUnique();

        builder.Property(x => x.PasswordHash)
        .HasColumnName("password_hash")
        .IsRequired();

        builder.Property(x => x.EmailVerified)
        .HasColumnName("email_verified")
        .IsRequired();

        builder.Property(x => x.Status)
        .HasColumnName("status")
        .HasConversion<string>()
        .HasMaxLength(50)
        .HasDefaultValue(UserStatus.PendingVerification)
        .IsRequired();

        builder.Property(x => x.FailedLoginAttempts)
        .HasColumnName("failed_login_attempts")
        .HasDefaultValue(0);

        builder.Property(x => x.LockedUntil)
        .HasColumnName("locked_until");

        builder.Property(x => x.LastLoginAt)
        .HasColumnName("last_login_at");

        builder.Property(x => x.CreatedAt)
        .HasColumnName("created_at")
        .IsRequired();

        builder.Property(x => x.UpdatedAt)
        .HasColumnName("updated_at")
        .IsRequired();

        builder.Property(x => x.DeletedAt)
        .HasColumnName("deleted_at");
    }
}