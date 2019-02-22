using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TripTracker.Models;

namespace TripTracker.Data
{
    public class TripContext: DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) 
            :base(options){}
        public TripContext(){}
        public DbSet<Trip> Trips { get; set; }
       
        
        public void SeedData( IServiceProvider serviceProvider)
        {
            //
           using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated();
            
            if(context.Trips.Any()) return;

          context.Trips.AddRange(new Trip[]
                {
                    
                        new Trip
                        {
                            Id = 1,
                            Name = "Trip to Spain",
                            StartDate = new DateTime(2018,5,4),
                            EndDate = new DateTime(2018,5,16),
                        },
                        new Trip 
                        {
                            Id = 2,
                            Name = "Trip to Netherlands",
                            StartDate = new DateTime(2018,6,13),
                            EndDate = new DateTime(2018,6,23),
                        },

                        new Trip 
                        {
                            Id = 3,
                            Name = "Trip to Bytom",
                            StartDate = new DateTime(2017,1,4),
                            EndDate = new DateTime(2017,1,7),
                        }
                }
            );
            context.SaveChanges();
        }
        }
    }
}