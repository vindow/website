using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Stats.Application.Dto
{
    public class GlobalMapStatsDto
    {
        public int totalCompletedMaps { get; set; }
        public int totalMaps { get; set; }
        public string topSubscribedMap { get; set; }
        public string topPlayedMap { get; set; }
        public string topDownloadedMap { get; set; }
        public string topUniquelyCompletedMap { get; set; }
    }
}
