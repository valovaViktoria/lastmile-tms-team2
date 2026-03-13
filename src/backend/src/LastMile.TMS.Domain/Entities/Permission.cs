using LastMile.TMS.Domain.Common;

namespace LastMile.TMS.Domain.Entities;

public enum PermissionScope
{
    Read,
    Write,
    Delete,
    All
}

public class Permission : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Module { get; set; } = string.Empty;
    public PermissionScope Scope { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}