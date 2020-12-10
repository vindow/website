using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Users.Core.Models
{
    public class Authentication
    {
        public string RefreshToken { get; set; }
        public DateTime IssuedAt { get; set; }
    }
}
