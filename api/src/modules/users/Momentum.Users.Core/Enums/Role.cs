using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Users.Core.Enums
{
    [Flags]
    public enum Role
    {
        VERIFIED = 1,
        MAPPER = 2,
        MODERATOR = 4,
        ADMIN = 8,
        PLACEHOLDER = 16
    }
}
