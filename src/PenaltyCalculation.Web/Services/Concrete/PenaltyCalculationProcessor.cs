using PenaltyCalculation.Web.Models;
using PenaltyCalculation.Web.Services.Abstract;
using System;

namespace PenaltyCalculation.Web.Services.Concrete
{
    public class PenaltyCalculationProcessor : IPenaltyCalculationProcessor
    {
        private readonly IPenaltyCalculationServiceFactoryPatternResolver _factoryPatternResolver;

        public PenaltyCalculationProcessor(IPenaltyCalculationServiceFactoryPatternResolver factoryPatternResolver)
        {
            _factoryPatternResolver = factoryPatternResolver;
        }

        public PenaltyOutputModel Process(PenaltyInputModel inputViewModel)
        {
            if (inputViewModel == null)
                throw new Exception($"{typeof(PenaltyInputModel).FullName} can not be null!");
            try
            {
                var _countryEnum = (CountryEnum)System.Enum.Parse(typeof(CountryEnum), inputViewModel.Country.Currency);

                var _penaltyCalculationService = _factoryPatternResolver.Resolve(_countryEnum);

                var businessDays = _penaltyCalculationService.GetBusinessDays(inputViewModel);

                var result = _penaltyCalculationService.Calculate(businessDays, inputViewModel.Country.Currency);

                return new PenaltyOutputModel { BusinessDays = businessDays, TotalPrice = result.TotalPrice, CurrencySymbol = result.Currency };
            }
            catch
            {
                
            }
            return new PenaltyOutputModel();
            
        }
    }
}
