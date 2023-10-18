using NodaTime;

namespace JupiterInv.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public Instant? LockoutEnd { get; set; } 
        public bool LockoutEnabled { get; set; }
        public Guid TenantId { get; set; } 
        public Tenant? Tenant { get; set; }
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
    }
}