using Microsoft.AspNetCore.Identity;

namespace JupiterInv.Core.Entities;

public class User : IdentityUser<Guid>
{
    public Guid TenantId { get; set; } 
    public Tenant? Tenant { get; set; }
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }

}