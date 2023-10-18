namespace JupiterInv.Core.Entities
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}