using System.Collections.Generic;
using TopSwagCode.AspNetCore.Beacon.Data;

namespace TopSwagCode.AspNetCore.Beacon.Models
{
    public class BeaconListResponse
    {
        public List<SessionAnalytic> Beacons { get; set; }
    }
}