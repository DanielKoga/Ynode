using System;
using Ynode.Domain.Core.Bus;
using Ynode.Domain.Core.Commands;
using Ynode.Domain.Core.Events;
using Ynode.Domain.Core.Notifications;

namespace Ynode.Infra.CrossCutting.Bus
{
    public class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        public static IServiceProvider Container => ContainerAccessor();


        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }
        private void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification") 
                ? typeof(IDomainNotificationHandler<T>) 
                : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message); 
        }
    }
}
