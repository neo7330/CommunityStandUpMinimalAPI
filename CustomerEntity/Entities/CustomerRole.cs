using System;
using System.Collections.Generic;

#nullable disable

namespace Customers.Core
{
    public partial class CustomerRole
    {
        public CustomerRole()
        {
            CustomerRoleMappings = new HashSet<CustomerRoleMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public string SystemName { get; set; }

        public virtual ICollection<CustomerRoleMapping> CustomerRoleMappings { get; set; }
    }
}
