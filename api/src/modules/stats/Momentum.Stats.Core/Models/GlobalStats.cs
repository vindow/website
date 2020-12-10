using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Stats.Core.Models
{
    public class GlobalStats
    {
        public string totalJumps { get; set; }
        public string totalStrafes { get; set; }
        public string runsSubmitted { get; set; }

        public MapStats MapStats { get; set; }
    }

    public class MapStats
    {
        public int totalCompletedMaps { get; set; }
        public int totalMaps { get; set; }
        public string topSubscribedMap { get; set; }
        public string topPlayedMap { get; set; }
        public string topDownloadedMap { get; set; }
        public string topUniquelyCompletedMap { get; set; }
    }
}
