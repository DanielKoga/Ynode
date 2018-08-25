using Ynode.Domain.Core.Commands;
using Ynode.Domain.Core.Events;

namespace Ynode.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
