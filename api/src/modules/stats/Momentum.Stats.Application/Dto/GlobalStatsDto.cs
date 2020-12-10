using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Momentum.Stats.Core.Models;

namespace Momentum.Stats.Application.Dto
{
    public class GlobalStatsDto
    {
        public string totalJumps { get; set; }
        public string totalStrafes { get; set; }
        public string runsSubmitted { get; set; }

        public GlobalMapStatsDto MapStats { get; set; }
    }
}
