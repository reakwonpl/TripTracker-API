using System;
using System.ComponentModel.DataAnnotations;
namespace TripTracker.DTO
{
    public class Trip
    {
         [Key]
        public int Id {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public DateTime StartDate {get;set;}
        [Required]
        public DateTime EndDate {get;set;}
    }
}