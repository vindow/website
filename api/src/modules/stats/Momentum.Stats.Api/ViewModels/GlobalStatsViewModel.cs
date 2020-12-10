using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Momentum.Stats.Application.Dto;

namespace Momentum.Stats.Api.ViewModels
{
    public class GlobalStatsViewModel
    {
        public string totalJumps { get; set; }
        public string totalStrafes { get; set; }
        public string runsSubmitted { get; set; }
        public GlobalStatsViewModel(GlobalStatsDto globalMapStatsDto)
        {
            totalJumps = globalMapStatsDto.totalJumps;
            totalStrafes = globalMapStatsDto.totalStrafes;
            runsSubmitted = globalMapStatsDto.runsSubmitted;
        }
    }
}
