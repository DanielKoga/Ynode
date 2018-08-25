using System.Collections.Generic;
using Ynode.Domain.Core.Events;

namespace Ynode.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        IList<T> GetNotifications();
    }
}
