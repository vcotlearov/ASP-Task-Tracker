using System.Collections.Generic;
using ATT.Infrastructure.Models.Security;

namespace ATT.Infrastructure.Models.Employee
{
    public interface IAccount : ISecurableObject
    {
        IEmployee Employee { get; }
        string AccountName { get; }
        string AccountPasswordHash { set; }
        AccountType AccountType { get; }
        IEnumerable<IRole> AccountRoles { get; }
    }

    public enum AccountType //redo this as enums are not compatible with SQL DB
    {
        Basic,
        Windows
    }
}
