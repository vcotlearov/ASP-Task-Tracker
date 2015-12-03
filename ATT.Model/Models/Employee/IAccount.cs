using System.Collections.Generic;
using ATT.Infrastructure.Models.Security;

namespace ATT.Infrastructure.Models.Employee
{
    public interface IAccount : ISecurableObject
    {
        IEmployee Employee { get; }
        string Name { get; }
        string PasswordHash { set; }
        AttAccountType Type { get; }
        IEnumerable<IRole> Roles { get; }
    }
}
