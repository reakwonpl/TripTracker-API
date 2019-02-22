using System.Collections.Generic;

namespace TripTracker.DTO
{
    public class TripWithSegments :Trip
    {
        public ICollection<Segment> Segments{get;set;}
    }
}