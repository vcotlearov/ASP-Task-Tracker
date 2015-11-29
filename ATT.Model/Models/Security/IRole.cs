using System.Collections.Generic;
using ATT.Infrastructure.Models.Project;

namespace ATT.Infrastructure.Models.Security
{
    public interface IRole
    {
        int Id { get; }
        string Title { get; }
        string Position { get; }
        IProject Project { get; }
        IEnumerable<IPermission> Permissions { get; }
    }
}