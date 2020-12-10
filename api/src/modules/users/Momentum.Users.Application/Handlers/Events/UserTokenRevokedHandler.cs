using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Momentum.Framework.Core.Events.UserEvents;

namespace Momentum.Users.Application.Handlers.Events
{
    public class UserTokenRevokedHandler : MediatR.INotificationHandler<UserTokenRevokedEvent>
    {
        private Core.Repository.IUserRepository m_repo;

        public UserTokenRevokedHandler(Core.Repository.IUserRepository repo)
        {
            m_repo = repo;
        }
        public async Task Handle(UserTokenRevokedEvent notification, CancellationToken cancellationToken)
        {
            var user = await m_repo.Get(notification.UserId);

            if (user == null)
                return;


            user.RevokeToken();

            await m_repo.Update(notification.UserId, user);
        }

    }
}
