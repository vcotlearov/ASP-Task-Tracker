using System.Collections.Generic;
using ATT.Infrastructure.Models.Employee;

namespace ATT.Infrastructure.Models.Security
{
    public interface ISecurable 
    {
        bool IsInheritedPermissions { get; }
        IEnumerable<IPermission> GetPermissionsForAccount(IAccount employeeAccount);

    }
}