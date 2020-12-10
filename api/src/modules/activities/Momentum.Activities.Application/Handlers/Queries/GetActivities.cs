using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Momentum.Activities.Application.Dto;
using Momentum.Activities.Core.Repository;

namespace Momentum.Activities.Application.Handlers.Queries
{
    public class GetActivities : IRequest<IReadOnlyList<Dto.ActivityDto>>
    {

    }

    public class GetActivitiesHandler : MediatR.IRequestHandler<GetActivities, IReadOnlyList<Dto.ActivityDto>>
    {
        private IActivityRepository m_repo;
        private IMapper m_mapper;

        public GetActivitiesHandler(IActivityRepository repo, IMapper mapper)
        {
            m_repo = repo;
            m_mapper = mapper;
        }
        public async Task<IReadOnlyList<ActivityDto>> Handle(GetActivities request, CancellationToken cancellationToken)
        {
            var items = await m_repo.Get();

            return m_mapper.Map<ActivityDto[]>(items.ToArray());
        }
    }

}
