using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Web.Models
{
    public class PenaltyOutputModel
    {
        public decimal TotalPrice { get; set; }
        public int BusinessDays { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
