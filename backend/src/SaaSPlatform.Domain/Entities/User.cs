using SaaSPlatform.Domain.Enums;

namespace SaaSPlatform.Domain.Entities;

public class User
{
    public long Id { get; set; }
    public Guid UserUuid { get; set; }
    public string? FullName { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool EmailVerified { get; set; } = false;
    public UserStatus Status { get; set; } = UserStatus.PendingVerification;
    public int FailedLoginAttempts { get; set; } = 0;
    public DateTimeOffset? LockedUntil { get; set; }
    public DateTimeOffset? LastLoginAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? DeletedAt { get; set; }
    
    // public ICollection<TenantMembership> TenantMemberships { get; set; } = new List<TenantMembership>();
    // public ICollection<Session> Sessions { get; set; } = new List<Session>();
    // public ICollection<OtpCode> OtpCodes { get; set; } = new List<OtpCode>();
    // public ICollection<Tenant> CreatedTenants { get; set; } = new List<Tenant>();
    public bool IsActive()
    {
        return Status == UserStatus.Active && EmailVerified && DeletedAt == null;
    }
    public void VerifyEmail()
    {
        EmailVerified = true;
        Status = UserStatus.Active;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
    public void MarkLoginSuccess()
    {
        FailedLoginAttempts = 0;
        LockedUntil = null;
        LastLoginAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
    public void MarkLoginFailed()
    {
        FailedLoginAttempts++;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
    public void LockUntil(DateTimeOffset lockedUntil)
    {
        Status = UserStatus.Locked;
        LockedUntil = lockedUntil;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
    public void Suspend()
    {
        Status = UserStatus.Suspended;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
    public void SoftDelete()
    {
        Status = UserStatus.Deleted;
        DeletedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
