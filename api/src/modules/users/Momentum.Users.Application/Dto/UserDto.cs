using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Users.Application.Dto
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime IssuedAt { get; set; }
    }
}
