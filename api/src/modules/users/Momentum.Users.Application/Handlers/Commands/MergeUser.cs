using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using momentum.framework.core.Services;
using Momentum.Users.Core.Repository;

namespace Momentum.Users.Application.Handlers.Commands
{
    public class MergeUser : IRequest
    {
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
    }

    public class MergeUserHandler : AsyncRequestHandler<MergeUser>
    {
        private IUserRepository m_repo;
        private IEventsPublisher m_publisher;

        public MergeUserHandler(IUserRepository repo, IEventsPublisher publisher)
        {
            m_repo = repo;
            m_publisher = publisher;
        }
        protected override async Task Handle(MergeUser request, CancellationToken cancellationToken)
        {
            var oldUser = await m_repo.Get(request.FromUserId);
            var newUser = Core.Models.User.FromUser(oldUser);

            await m_repo.Save(newUser);

            await m_publisher.Publish(newUser.Events);
        }
    }
}
