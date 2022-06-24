using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Core
{
    internal class InvariantSeedData
    {
        public static IList<CustomerRole> CustomerRoles()
        {
            var entities = new List<CustomerRole>
            {
                new CustomerRole
                {
                    Id = 1,
                    Name = "Administrators",
                    Active = true,
                    IsSystemRole = true,
                    SystemName = SystemCustomerRoleNames.Administrators,
                },
                new CustomerRole
                {
                    Id = 2,
                    Name = "Supervisor",
                    Active = true,
                    IsSystemRole = true,
                    SystemName = SystemCustomerRoleNames.Supervisor,
                },
                new CustomerRole
                {
                    Id = 3,
                    Name = "Registered",
                    Active = true,
                    IsSystemRole = true,
                    SystemName = SystemCustomerRoleNames.Registered,
                },
                new CustomerRole
                {
                    Id = 4,
                    Name = "Guests",
                    Active = true,
                    IsSystemRole = true,
                    SystemName = SystemCustomerRoleNames.Guests,
                }
            };

            return entities;
        }

        public static IList<Customer> Customers()
        {
            var salt = PasswordUtils.CreateSaltKey();
            var entities = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@vnitsolution.com",
                    PasswordFormatId = (int) PasswordFormat.Hashed,
                    PasswordSalt = salt,
                    Password = PasswordUtils.CreatePasswordHash("Ne0!TheCh0$en1", salt),
                    Active = true,
                    CreatedOnUtc = DateTime.UtcNow,
                    SystemName = SystemCustomerRoleNames.Administrators
                }
            };

            return entities;
        }

        public static IList<CustomerRoleMapping> CustomerRoleMappings()
        {
            var entities = new List<CustomerRoleMapping>
            {
                new CustomerRoleMapping
                {
                    Id = 1,
                    CustomerId = 1,
                    CustomerRoleId = 1
                }
            };

            return entities;
        }
    }
}
