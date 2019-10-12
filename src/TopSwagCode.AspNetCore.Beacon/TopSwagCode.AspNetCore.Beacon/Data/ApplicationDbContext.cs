using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionAnalytic>()
                .HasMany(p => p.Analytics)
                .WithOne();
            
            modelBuilder.Entity<Analytic>()
                .HasOne(p => p.Analytics)
                .WithOne();
        }
    }
    
    

    public class SessionAnalytic
    {
        public Guid SessionUid { get; set; }
        public string UserId { get; set; }
        
        public List<Analytic> Analytics { get; set; }
    }

    public class Analytic
    {
        public int Id { get; set; }
        public string State { get; set; }
        public DateTimeOffset UserTime { get; set; }
        
        [ForeignKey("SessionAnalyticForeignKey")]
        public Guid SessionUid { get; set; }
        
        
        public SessionAnalytic SessionAnalytic { get; set; }
    }
}