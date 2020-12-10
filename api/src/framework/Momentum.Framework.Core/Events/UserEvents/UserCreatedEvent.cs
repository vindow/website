using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Momentum.Framework.Core;

namespace Momentum.Framework.Core.Events.UserEvents
{
    public class UserCreatedEvent : IInternalEvent, INotification //TODO: convert everything from IInternalEvent to INotification
    {
        public Guid UserId { get; set; }
    }
}
