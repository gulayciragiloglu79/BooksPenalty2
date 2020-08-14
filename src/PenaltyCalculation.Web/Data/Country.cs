using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Web.Data
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public List<Holiday> Holidays { get; set; }
    }
}
