using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Momentum.Stats.Api.ViewModels;
using Momentum.Stats.Application.Dto;

namespace Momentum.Stats.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly ILogger<StatsController> _logger;
        private IMediator m_mediator;
        public StatsController(IMediator mediator, ILogger<StatsController> logger)
        {
            _logger = logger;
            m_mediator = mediator;
        }

        [HttpGet]
        public async Task<GlobalStatsViewModel> Get()
        {
            var request = new Application.Handlers.Queries.GetStats();
            var result = await m_mediator.Send(request);

            return new GlobalStatsViewModel(result);
        }

        [HttpGet("/maps")]
        public async Task<GlobalMapStatsViewModel> GetMapStats()
        {
            var request = new Application.Handlers.Queries.GetStats();
            var result = await m_mediator.Send(request);
            return new GlobalMapStatsViewModel(result);
        }
    }
}
