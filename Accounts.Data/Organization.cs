namespace Accounts.Data
{
    public class Organization : Item
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}