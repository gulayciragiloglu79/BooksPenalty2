using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Web.Data
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
