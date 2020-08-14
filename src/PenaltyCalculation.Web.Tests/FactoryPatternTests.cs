using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.FactoryPattern;
using PenaltyCalculation.Web.Services;
using PenaltyCalculation.Web.Services.Abstract;
using PenaltyCalculation.Web.Services.Concrete;
using System;
using Xunit;

namespace PenaltyCalculation.Web.Tests
{
    public class FactoryPatternTests
    {
        private readonly IPenaltyCalculationServiceFactoryPatternResolver factoryPatternResolver;

        public FactoryPatternTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(TurkeyPenaltyCalculationService), CountryEnum.TR.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(UnitedArabEmiratesPenaltyCalculationService), CountryEnum.AE.GetName(), ServiceLifetime.Transient);

            serviceCollection.AddTransient<IPenaltyCalculationServiceFactoryPatternResolver, PenaltyCalculationServiceFactoryPatternResolver>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            factoryPatternResolver = serviceProvider.GetService<IPenaltyCalculationServiceFactoryPatternResolver>();
        }
        [Fact]
        public void FactoryPatternTest()
        {
            var _TurkeyPenaltyCalculationService = factoryPatternResolver.Resolve(CountryEnum.TR);

            Assert.NotNull(_TurkeyPenaltyCalculationService);
            Assert.IsType<TurkeyPenaltyCalculationService>(_TurkeyPenaltyCalculationService);


            var _UnitedArabEmiratesPenaltyCalculationService = factoryPatternResolver.Resolve(CountryEnum.AE);

            Assert.NotNull(_UnitedArabEmiratesPenaltyCalculationService);
            Assert.IsType<UnitedArabEmiratesPenaltyCalculationService>(_UnitedArabEmiratesPenaltyCalculationService);
        }
    }
}
