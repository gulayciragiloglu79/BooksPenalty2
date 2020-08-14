using PenaltyCalculation.Web.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Web.Models
{
    public class PenaltyInputModel
    {
        [Required(ErrorMessage = "Please enter book out date")]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [Required(ErrorMessage = "Please enter book in date")]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
        [Required(ErrorMessage = "Please select country")]
        public Country Country { get; set; }
    }
}
