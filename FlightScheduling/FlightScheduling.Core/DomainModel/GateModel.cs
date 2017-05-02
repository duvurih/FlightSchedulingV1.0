using System.ComponentModel.DataAnnotations;

namespace FlightScheduling.Core.DomainModel
{
    public class GateModel : DomainBase
    {
        [Display(Name = "Gate ID")]
        [Required(ErrorMessage = "The Gate ID is a required field.")]
        public int GateID { get; set; }

        [Display(Name = "Gate Name")]
        [Required(ErrorMessage = "The Gate Name is a required field.")]
        [MinLength(5, ErrorMessage = "The minimum length of the Gate Name is 5 characters.")]
        [MaxLength(25, ErrorMessage = "The maximum length of the Gate Name is 25 characters.")]
        public string GateName { get; set; }

        [Display(Name = "Gate Location")]
        [Required(ErrorMessage = "The Gate Location is a required field.")]
        [MinLength(5, ErrorMessage = "The minimum length of the Gate Location is 5 characters.")]
        [MaxLength(25, ErrorMessage = "The maximum length of the Gate Location is 25 characters.")]
        public string GateLocation { get; set; }

        public int FlightCounter { get; set; }
    }
}
