using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Momentum.Stats.Application.Dto;

namespace Momentum.Stats.Api.ViewModels
{
    public class GlobalMapStatsViewModel
    {
        public int totalCompletedMaps { get; set; }
        public int totalMaps { get; set; }
        public string topSubscribedMap { get; set; }
        public string topPlayedMap { get; set; }
        public string topDownloadedMap { get; set; }
        public string topUniquelyCompletedMap { get; set; }

        public GlobalMapStatsViewModel(GlobalStatsDto globalMapStatsDto)
        {
            totalCompletedMaps = globalMapStatsDto.MapStats.totalCompletedMaps;
            totalMaps = globalMapStatsDto.MapStats.totalMaps;
            topSubscribedMap = globalMapStatsDto.MapStats.topSubscribedMap;
            topPlayedMap = globalMapStatsDto.MapStats.topPlayedMap;
            topDownloadedMap = globalMapStatsDto.MapStats.topDownloadedMap;
            topUniquelyCompletedMap = globalMapStatsDto.MapStats.topUniquelyCompletedMap;
        }
    }
}
