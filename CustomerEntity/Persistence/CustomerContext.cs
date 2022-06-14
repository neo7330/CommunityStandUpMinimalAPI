using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Customers.Core
{
    public partial class CustomerContext : DbContext
    {
        public CustomerContext()
        {
        }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerRole> CustomerRoles { get; set; }
        public virtual DbSet<CustomerRoleMapping> CustomerRoleMappings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=us-customer;Integrated Security=False;Persist Security Info=False; User ID=sa;Password=Password@123;Enlist=False;Pooling=True;Min Pool Size=1;Max Pool Size=100; MultipleActiveResultSets=True;Connect Timeout=15;User Instance=False");
            }
#endif
        }
    }
}
