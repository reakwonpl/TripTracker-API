using System;
using System.Collections.Generic;

namespace TripTracker.Models
{
    public class Trip : DTO.Trip
    {
        // [Key]
        // public int Id {get;set;}
        // [Required]
        // public string Name {get;set;}
        // [Required]
        // public DateTime StartDate {get;set;}
        // [Required]
        // public DateTime EndDate {get;set;}
        public virtual ICollection<Segment> Segments {get;set;}
    

    }
}