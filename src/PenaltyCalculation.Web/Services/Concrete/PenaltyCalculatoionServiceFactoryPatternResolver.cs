using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.FactoryPattern;
using PenaltyCalculation.Web.Services.Abstract;
using System;

namespace PenaltyCalculation.Web.Services.Concrete
{
    public class PenaltyCalculationServiceFactoryPatternResolver : FactoryPatternResolver<IPenaltyCalculationService, CountryEnum>, IPenaltyCalculationServiceFactoryPatternResolver
    {

        public PenaltyCalculationServiceFactoryPatternResolver(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            
        }
    }
}
