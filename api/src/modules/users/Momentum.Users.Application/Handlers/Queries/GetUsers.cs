using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Momentum.Users.Application.Dto;
using Momentum.Users.Core.Repository;
using AutoMapper;

namespace Momentum.Users.Application.Handlers.Queries
{
    public class GetUsers : IRequest<Dto.UserDto[]>
    {

    }

    public class GetUsersHandler : IRequestHandler<GetUsers, Dto.UserDto[]>
    {
        private IUserRepository m_repo;
        private IMapper m_mapper;

        public GetUsersHandler(IUserRepository repo, IMapper mapper)
        {
            m_repo = repo;
            m_mapper = mapper;
        }

        public async Task<UserDto[]> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            var items = await m_repo.Get();
            return m_mapper.Map<UserDto[]>(items);
        }
    }
}
