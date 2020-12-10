using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Momentum.Framework.Core.Events.UserEvents
{
    public class UserTokenRevokedEvent : IInternalEvent, INotification
    {
        public Guid UserId { get; set; }
    }
}
