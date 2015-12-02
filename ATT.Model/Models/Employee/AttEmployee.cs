using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATT.Infrastructure.Models.Security;

namespace ATT.Infrastructure.Models.Employee
{
    public class AttEmployee: IEmployee
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid EUID { get; set; }
        public byte[] Photo { get; set; }
        public bool IsInheritedPermissions { get; set; }
        public IEnumerable<IPermission> GetPermissionsForAccount(IAccount employeeAccount)
        {
            throw new NotImplementedException();
        }

        public ISecurableObject Parent { get; set; }

        public AttEmployee()
        {
        }

        public AttEmployee(int id)
        {
            Id = id;
        }
    }
}
