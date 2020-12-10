using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using momentum.framework.core.Events.UserEvents;

namespace momentum.activities.application.Handlers.Events
{
    public class MigratedUserEventHandler : INotificationHandler<framework.core.Events.UserEvents.NewUserEvent>
    {

        async Task INotificationHandler<NewUserEvent>.Handle(NewUserEvent notification, CancellationToken cancellationToken)
        {
            if (!notification.FromUserId.HasValue)
                return;



            //TODO: Merge activities
            return;
        }
    }
}
