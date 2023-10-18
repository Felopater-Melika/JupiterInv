namespace JupiterInv.Core.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public Guid TenantId { get; set; }
        public Tenant? Tenant { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
