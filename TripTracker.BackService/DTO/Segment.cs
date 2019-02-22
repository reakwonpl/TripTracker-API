using System;
using System.ComponentModel.DataAnnotations;

namespace TripTracker.DTO
{
    public class Segment
    {
        public int Id {get;set;}
        [Required]
        public int TripId {get;set;}
        public string Name{get;set;}
        public string Description {get;set;}
        [Required]
        public DateTimeOffset StartDateTime{get;set;}
        [Required]
        public DateTimeOffset EndDateTime{get;set;}
    }
}