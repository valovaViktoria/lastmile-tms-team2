using LastMile.TMS.Domain.Common;

namespace LastMile.TMS.Domain.Entities;

public class User : BaseAuditableEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public Guid RoleId { get; set; }
    public Guid? ZoneId { get; set; }

    public virtual Role? Role { get; set; }
}