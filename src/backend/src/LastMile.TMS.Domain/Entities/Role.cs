using LastMile.TMS.Domain.Common;

namespace LastMile.TMS.Domain.Entities;

public enum PredefinedRole
{
    Admin,
    OperationsManager,
    Dispatcher,
    WarehouseOperator,
    Driver
}

public class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsDefault { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}