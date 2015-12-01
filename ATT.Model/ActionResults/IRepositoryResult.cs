using System.Collections.Generic;
using ATT.Infrastructure.Models;

namespace ATT.Infrastructure.ActionResults
{
    public interface IRepositoryResult : IResult
    {
        IEnumerable<ISecurableObject> RepositoryObjects { get; }
    }
}