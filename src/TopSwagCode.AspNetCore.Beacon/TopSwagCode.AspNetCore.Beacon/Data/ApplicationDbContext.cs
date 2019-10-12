using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TopSwagCode.AspNetCore.Beacon.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Analytic> Analytics { get; set; }
        public DbSet<SessionAnalytic> SessionAnalytics { get; set; }
    }

    public class SessionAnalytic
    {
        public string SessionId { get; set; } // PrimaryKey
        public string UserId { get; set; } // If known
    }

    public class Analytic
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string SessionId { get; set; } // ForeignKey
        public DateTimeOffset UserTime { get; set; }
    }
}