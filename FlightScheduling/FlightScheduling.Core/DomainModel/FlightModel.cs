using System;
using System.ComponentModel.DataAnnotations;

namespace FlightScheduling.Core.DomainModel
{
    public class FlightModel : DomainBase
    {
        [Display(Name = "Flight ID")]
        [Required(ErrorMessage = "The Flight ID is a required field.")]
        public int FlightID { get; set; }

        [Display(Name = "Gate ID")]
        [Required(ErrorMessage = "The Gate ID is a required field.")]
        public int GateID { get; set; }


        [Display(Name = "Flight Name")]
        [Required(ErrorMessage = "The Flight Name is a required field.")]
        [MinLength(5, ErrorMessage = "The minimum length of the Flight Name is 5 characters.")]
        [MaxLength(25, ErrorMessage = "The maximum length of the Flight Name is 25 characters.")]
        public string FlightName { get; set; }

        [Display(Name = "Arrival Time")]
        [Required(ErrorMessage = "The arrival time is a required field.")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Departure Time")]
        [Required(ErrorMessage = "The departure time is a required field.")]
        public DateTime DepartureTime { get; set; }

        [Display(Name = "Flight Cancellation Status")]
        [Required(ErrorMessage = "The flight cancellation status is a required field.")]
        public bool CancellationStatus { get; set; }

        [Display(Name = "Flight Rescheduled")]
        public bool Rescheduled { get; set; }
    }
}
