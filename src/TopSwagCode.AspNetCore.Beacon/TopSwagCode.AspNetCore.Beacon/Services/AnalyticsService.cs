using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopSwagCode.AspNetCore.Beacon.Data;
using TopSwagCode.AspNetCore.Beacon.Models;

namespace TopSwagCode.AspNetCore.Beacon.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly InmemoryAnalytics _inMemoryAnalytics;

        public AnalyticsService()
        {
            _inMemoryAnalytics = InmemoryAnalytics.GetInstance();
        }

        public void InsertAnalytics(BeaconRequest beaconRequest, string userId = "")
        {
            var sessionAnalytic = _inMemoryAnalytics.SessionAnalytics.SingleOrDefault(x => x.SessionUid == beaconRequest.SessionUid);

            if (sessionAnalytic == null)
            {
                sessionAnalytic = new SessionAnalytic
                {
                    SessionUid = beaconRequest.SessionUid,
                };
                
                _inMemoryAnalytics.SessionAnalytics.Add(sessionAnalytic);
            }

            if (string.IsNullOrEmpty(sessionAnalytic.UserId) && string.IsNullOrEmpty(userId) == false)
            {
                sessionAnalytic.UserId = userId;
            }
            
            sessionAnalytic.Analytics.Add(new Analytic
            {
                State = beaconRequest.State,
                UserTime = beaconRequest.UserTime,
                Location = beaconRequest.Location,
            });
        }

        public List<SessionAnalytic> GetAnalytics()
        {
            return _inMemoryAnalytics.SessionAnalytics;
        }
    }
}