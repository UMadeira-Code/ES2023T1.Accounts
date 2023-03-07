using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Accounts.Data.Store
{
    public class AccountsContext : DbContext
    {
        public AccountsContext()
        {
        }

        protected override void OnConfiguring( DbContextOptionsBuilder builder )
        {
            builder
                .LogTo( message => Console.WriteLine( $"-----\n{message}\n-----" ) , LogLevel.Information )
                .UseLazyLoadingProxies()
                .UseSqlServer( @"data source=(LocalDb)\MSSQLLocalDB;" +
                                  @"initial catalog=Accounts2023T1;" +
                                  @"integrated security=True" );
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder.Entity<Organization>()
                .Property(o => o.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(128)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(16)
                .IsRequired();

            builder.Entity<Organization>()
                .HasMany( o => o.Users )
                .WithOne();
        }

        public DbSet<Organization> Organizations { get; set; }
    }
}