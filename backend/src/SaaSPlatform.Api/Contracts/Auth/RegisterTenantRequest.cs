
using System.ComponentModel.DataAnnotations;

namespace SaaSPlatform.Api.Dtos;

public class RegisterTenantRequest
{
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    [MaxLength(100)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string TenantSlug { get; set; } = string.Empty;
}