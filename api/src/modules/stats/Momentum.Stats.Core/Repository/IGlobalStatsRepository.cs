using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Stats.Core.Repository
{
    public interface IGlobalStatsRepository
    {
        public Task<Models.GlobalStats> Get();
    }
}
