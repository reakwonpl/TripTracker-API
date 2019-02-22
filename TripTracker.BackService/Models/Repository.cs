using System;
using System.Collections.Generic;
using System.Linq;

namespace TripTracker.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
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
        };

        public List<Trip> Get()
        {
            return MyTrips;
        }

        public Trip Get(int id)
        {
            return MyTrips.First( x => x.Id == id);
        }

        public void Add(Trip newTrip)
        {
            MyTrips.Add(newTrip);
            Console.WriteLine("Added {0}",newTrip);
        }

        public void Update(Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First( o => o.Id == tripToUpdate.Id));
            Add(tripToUpdate);
            Console.WriteLine("Updated {0}",tripToUpdate);
        }

        public void Remove(int id)
        {
            MyTrips.Remove(MyTrips.First(o => o.Id == id));
            Console.WriteLine("Removed {0}",id);
        }
    }
}