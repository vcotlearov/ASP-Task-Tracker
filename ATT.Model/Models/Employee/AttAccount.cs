using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATT.Infrastructure.Models.Security;

namespace ATT.Infrastructure.Models.Employee
{
    public class AttAccount : ISecurableObject
    {

        public int Id { get; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public Guid EUID { get; set; }
        public bool IsInheritedPermissions { get; }
        public ISecurableObject Parent { get; }

        public AttAccount()
        {
        }

        public AttAccount(int id)
        {
            Id = id;
        }

        public IEnumerable<IPermission> GetPermissionsForAccount(IAccount employeeAccount)
        {
            throw new NotImplementedException();
        }

        


    }
}
