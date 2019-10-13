using System.Collections.Generic;

namespace TopSwagCode.AspNetCore.Beacon.Data
{
    
    public class InmemoryAnalytics
    {
        private static InmemoryAnalytics Instance { get; set; }

        public InmemoryAnalytics()
        {
            SessionAnalytics = new List<SessionAnalytic>();
        }
        
        
        public static InmemoryAnalytics GetInstance()
        {
            if (Instance == null)
            {
                Instance = new InmemoryAnalytics();
            }

            return Instance;
        }
        
        public List<SessionAnalytic> SessionAnalytics { get; set; }
        
    }
}