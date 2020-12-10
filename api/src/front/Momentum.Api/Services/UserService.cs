using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Momentum.Framework.Core.Services;
using Momentum.Framework.Core.Models;

namespace Momentum.Api.Services
{

    public class UserService : IUserService
    {
        private HttpContext m_httpcontext;
        public UserService(HttpContext httpcontext)
        {
            m_httpcontext = httpcontext;
        }
        private User currentUser;

        public async Task<User> GetCurrentUser()
        {
            if (currentUser != null)
                return currentUser;


            var userId = m_httpcontext.Request.Headers["UserId"];

            //get user from headers
            return new User()
            {
                UserId = Guid.Parse(userId)
            };
        }
    }
}
