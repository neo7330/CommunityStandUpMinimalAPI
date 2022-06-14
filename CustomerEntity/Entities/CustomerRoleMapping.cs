using System;
using System.Collections.Generic;

#nullable disable

namespace Customers.Core
{
    public partial class CustomerRoleMapping
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CustomerRoleId { get; set; }
        public bool IsSystemMapping { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
