using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Customers.Core
{
    public partial class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerRole> CustomerRoles { get; set; }
        public virtual DbSet<CustomerRoleMapping> CustomerRoleMappings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerRole>().HasData(InvariantSeedData.CustomerRoles());
            modelBuilder.Entity<Customer>().HasData(InvariantSeedData.Customers());
            modelBuilder.Entity<CustomerRoleMapping>().HasData(InvariantSeedData.CustomerRoleMappings());
        }
    }
}
