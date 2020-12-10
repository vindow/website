using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;

namespace Momentum.Activities.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly ILogger<ActivitiesController> _logger;
        private IMediator m_mediator;


        public ActivitiesController(IMediator mediator, ILogger<ActivitiesController> logger)
        {
            _logger = logger;
            m_mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Application.Dto.ActivityDto>> Get()
        {
            var request = new Application.Handlers.Queries.GetActivities();
            return await m_mediator.Send(request);
        }
    }
}
