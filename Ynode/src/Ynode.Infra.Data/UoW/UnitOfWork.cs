using System.Threading.Tasks;
using Ynode.Domain.Core.Commands;
using Ynode.Domain.Interfaces;
using Ynode.Infra.Data.Context;

namespace Ynode.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YnodeContext _context;

        public UnitOfWork(YnodeContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public async Task<CommandResponse> CommitAsync()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
