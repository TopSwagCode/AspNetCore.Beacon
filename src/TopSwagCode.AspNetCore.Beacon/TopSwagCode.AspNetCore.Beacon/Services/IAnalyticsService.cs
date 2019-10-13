using System.Collections.Generic;
using TopSwagCode.AspNetCore.Beacon.Data;
using TopSwagCode.AspNetCore.Beacon.Models;

namespace TopSwagCode.AspNetCore.Beacon.Services
{
    public interface IAnalyticsService
    {
        void InsertAnalytics(BeaconRequest beaconRequest, string userId);
        List<SessionAnalytic> GetAnalytics();
    }
}