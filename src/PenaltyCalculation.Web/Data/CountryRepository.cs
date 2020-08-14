using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Web.Data
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Country> AllCountries => _appDbContext.Countries;

        public Country GetCountryById(int countryId)
        {
            return _appDbContext.Countries.Include(h => h.Holidays).FirstOrDefault(c => c.CountryId == countryId);
        }
    }
}
