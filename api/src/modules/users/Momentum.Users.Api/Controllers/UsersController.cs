using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Momentum.Framework.Core.Services;

namespace Momentum.Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IUserService m_userService;
        private IMediator m_mediator;

        public UsersController(IUserService userService, IMediator mediator, ILogger<UsersController> logger)
        {
            _logger = logger;
            m_userService = userService;
            m_mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var request = new Application.Handlers.Queries.GetUsers();
            var response = await m_mediator.Send(request);

            return Ok(new
            {
                users = response,
                count = response.Count()
            });
        }



        [HttpGet]
        public async Task<object> GetUserProfile()
        {
            var currentUser = await m_userService.GetCurrentUser();

            var request = new Application.Handlers.Queries.GetProfileByUserId()
            {
                UserId = currentUser.UserId
            };

            var response = m_mediator.Send(request);
            return response;
        }
    }
}
