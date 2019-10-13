using System;
using System.Collections.Generic;

namespace TopSwagCode.AspNetCore.Beacon.Data
{
    public class SessionAnalytic
    {
        public SessionAnalytic()
        {
            Analytics = new List<Analytic>();
        }
        
        public Guid SessionUid { get; set; }
        public string UserId { get; set; }
        
        public List<Analytic> Analytics { get; set; }
    }
}