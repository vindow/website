using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Momentum.Users.Application.Dto;
using Momentum.Users.Core.Repository;

namespace Momentum.Users.Application.Handlers.Queries
{
    public class UserById : IRequest<Dto.UserDto>
    {
        public Guid UserId { get; set; }
        public bool Expand { get; set; }
    }

    public class UserByIdHandler : IRequestHandler<UserById, Dto.UserDto>
    {
        private IUserRepository m_repo;
        private IMapper m_mapper;

        public UserByIdHandler(IUserRepository repo, IMapper mapper)
        {
            m_repo = repo;
            m_mapper = mapper;
        }

        public async Task<UserDto> Handle(UserById request, CancellationToken cancellationToken)
        {
            var item = await m_repo.Get(request.UserId);
            return m_mapper.Map<UserDto>(item);
        }
    }
}
