using System;
using System.Collections.Generic;

#nullable disable

namespace Customers.Core
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerRoleMappings = new HashSet<CustomerRoleMapping>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PasswordFormatId { get; set; }
        public string PasswordSalt { get; set; }
        public string AdminComment { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string SystemName { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string CustomerNumber { get; set; }

        public virtual ICollection<CustomerRoleMapping> CustomerRoleMappings { get; set; }
    }
}
