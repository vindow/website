using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Momentum.Stats.Application.Dto;
using Momentum.Stats.Core.Repository;

namespace Momentum.Stats.Application.Handlers.Queries
{
    public class GetStats : IRequest<Dto.GlobalStatsDto>
    {

    }

    public class GetStatsHandler : IRequestHandler<GetStats, Dto.GlobalStatsDto>
    {
        private IGlobalStatsRepository m_repo;
        private IMapper m_mapper;

        public GetStatsHandler(IGlobalStatsRepository repo, IMapper mapper)
        {
            m_repo = repo;
            m_mapper = mapper;
        }

        public async Task<GlobalStatsDto> Handle(GetStats request, CancellationToken cancellationToken)
        {
            var item = await m_repo.Get();

            return m_mapper.Map<GlobalStatsDto>(item);
        }
    }
}
