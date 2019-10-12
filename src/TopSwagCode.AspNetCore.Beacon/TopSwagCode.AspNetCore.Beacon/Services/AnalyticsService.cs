using System.Threading.Tasks;
using TopSwagCode.AspNetCore.Beacon.Data;

namespace TopSwagCode.AspNetCore.Beacon.Services
{

    public interface IAnalyticsService
    {
        Task InsertAnalytics(Analytic analytic);
    }
    
    public class AnalyticsService
    {
        private readonly ApplicationDbContext _dbContext;

        public AnalyticsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertAnalytics(Analytic analytic)
        {
            _dbContext.Analytics.Add(analytic);

            await _dbContext.SaveChangesAsync();

        }
    }
}