using Microsoft.Extensions.DependencyInjection.FactoryPattern;

namespace PenaltyCalculation.Web.Services.Abstract
{
    public  interface IPenaltyCalculationServiceFactoryPatternResolver :IFactoryPatternResolver<IPenaltyCalculationService, CountryEnum>
    {
    }
}
