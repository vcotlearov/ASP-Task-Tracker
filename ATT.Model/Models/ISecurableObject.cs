using ATT.Infrastructure.Models.Security;

namespace ATT.Infrastructure.Models
{
    public interface ISecurableObject : ISecurable, IObject
    {
        ISecurableObject Parent { get; }
    }
}