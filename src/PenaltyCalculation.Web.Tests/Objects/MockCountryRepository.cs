using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PenaltyCalculation.Web.Data;

namespace PenaltyCalculation.Web.Tests.Objects
{
    public class MockCountryRepository :ICountryRepository
    {

        private IEnumerable<Holiday> HolidaysList => new List<Holiday> {
            new Holiday { HolidayId = 1, Name = "Eid", Date = new DateTime(2020, 8, 1), CountryId = 1 },
            new Holiday { HolidayId = 2, Name = "Eid", Date = new DateTime(2020, 8, 2), CountryId = 1 },
            new Holiday { HolidayId = 3, Name = "Eid", Date = new DateTime(2020, 8, 3), CountryId = 1 },
            new Holiday { HolidayId = 4, Name = "30 Ağustos Zafer Bayramı", Date = new DateTime(2020, 8, 30), CountryId = 1 }
        };

        private  IEnumerable<Country> AllCountriesList => new List<Country> {
            new Country { CountryId = 1, Name = "Turkey", Currency = "TR" ,Holidays=HolidaysList.ToList()},
            new Country { CountryId = 2, Name = "United Arab Emirates", Currency = "AE" ,Holidays= new List<Holiday>() }
        };

        public  IEnumerable<Country> AllCountries =>  AllCountriesList;

        public Country GetCountryById(int countryId)
        {
            return AllCountriesList.FirstOrDefault(c => c.CountryId == countryId);
        }
   
    }
}
