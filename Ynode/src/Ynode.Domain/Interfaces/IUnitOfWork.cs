using System;
using System.Threading.Tasks;
using Ynode.Domain.Core.Commands;

namespace Ynode.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
        Task<CommandResponse> CommitAsync();
    }
}
