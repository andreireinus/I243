using System.Threading.Tasks;
using Vault.Core.Entities;

namespace Vault.Core
{
    public interface INotifier
    {
        Task<OperationResult> SendAsync(Lender lender, string subject, string message);
    }
}