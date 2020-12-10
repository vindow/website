using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Users.Core.Enums
{
    [Flags]
    public enum Ban
    {
        BANNED_LEADERBOARDS = 1,
        BANNED_ALIAS = 2,
        BANNED_AVATAR = 4,
        BANNED_BIO = 8
    }

}
