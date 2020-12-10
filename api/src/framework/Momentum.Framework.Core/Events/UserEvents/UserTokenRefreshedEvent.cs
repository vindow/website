using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Momentum.Framework.Core.Events.UserEvents
{
    public class UserTokenRefreshedEvent : IInternalEvent, INotification
    {
        public Guid UserId { get; set; }

        public string RefreshToken { get; set; }

        public DateTime IssuedAt { get; set; }
    }
}
