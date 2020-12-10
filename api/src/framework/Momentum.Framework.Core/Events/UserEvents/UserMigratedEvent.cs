using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Momentum.Framework.Core.Events.UserEvents
{
    public class UserMigratedEvent : IInternalEvent, INotification //TODO: convert everything from IInternalEvent to INotification
    {
        public Guid UserId { get; set; }

        public Guid FromUserId { get; set; }

    }
}
