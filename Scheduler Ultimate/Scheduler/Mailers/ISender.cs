using System.Threading;
using System.Threading.Tasks;
using FluentEmail.Core.Models;

namespace Scheduler
{
    public interface ISender
    {
        SendResponse Send(Email email, CancellationToken? token = null);
        Task<SendResponse> SendAsync(Email email, CancellationToken? token = null);
    }
}
