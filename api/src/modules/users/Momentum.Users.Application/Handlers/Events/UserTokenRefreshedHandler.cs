using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Momentum.Framework.Core.Events.UserEvents;

namespace Momentum.Users.Application.Handlers.Events
{
    public class UserTokenRefreshedHandler : MediatR.INotificationHandler<UserTokenRefreshedEvent>
    {
        private Core.Repository.IUserRepository m_repo;

        public UserTokenRefreshedHandler(Core.Repository.IUserRepository repo)
        {
            m_repo = repo;
        }
        public async Task Handle(UserTokenRefreshedEvent notification, CancellationToken cancellationToken)
        {
            var user = await m_repo.Get(notification.UserId);

            if (user == null)
                return;


            user.ApplyToken(notification.RefreshToken, notification.IssuedAt);

            await m_repo.Update(notification.UserId, user);
        }
    }
}
