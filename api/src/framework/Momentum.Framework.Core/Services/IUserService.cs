using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Framework.Core.Services
{
    public interface IUserService
    {
        Task<Models.User> GetCurrentUser();
    }
}
