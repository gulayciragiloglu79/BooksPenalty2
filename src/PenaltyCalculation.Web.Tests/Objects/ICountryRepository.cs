using PenaltyCalculation.Web.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyCalculation.Web.Tests.Objects
{
    public interface ICountryRepository
    {
        IEnumerable<Country> AllCountries { get; }
        Country GetCountryById(int countryId);
    }
}
