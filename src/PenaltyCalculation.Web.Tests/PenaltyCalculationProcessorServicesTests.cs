using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.FactoryPattern;
using PenaltyCalculation.Web.Data;
using PenaltyCalculation.Web.Models;
using PenaltyCalculation.Web.Services;
using PenaltyCalculation.Web.Services.Abstract;
using PenaltyCalculation.Web.Services.Concrete;
using PenaltyCalculation.Web.Tests.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xunit;

namespace PenaltyCalculation.Web.Tests
{
    public class PenaltyCalculationProcessorServicesTests
    {
        private readonly IPenaltyCalculationServiceFactoryPatternResolver factoryPatternResolver;
        private readonly MockCountryRepository _mockRepo;
        private readonly IPenaltyCalculationProcessor penaltyCalculationProcessor;

        PenaltyInputModel  _inputModel = new PenaltyInputModel() { From = new DateTime(2020, 8, 1), To = new DateTime(2020, 8, 9),Country=null };

        public PenaltyCalculationProcessorServicesTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(TurkeyPenaltyCalculationService), CountryEnum.TR.GetName(), ServiceLifetime.Transient);
            serviceCollection.Add(typeof(IPenaltyCalculationService), typeof(UnitedArabEmiratesPenaltyCalculationService), CountryEnum.AE.GetName(), ServiceLifetime.Transient);

            serviceCollection.AddTransient<IPenaltyCalculationServiceFactoryPatternResolver, PenaltyCalculationServiceFactoryPatternResolver>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            factoryPatternResolver = serviceProvider.GetService<IPenaltyCalculationServiceFactoryPatternResolver>();

            penaltyCalculationProcessor = new PenaltyCalculationProcessor(factoryPatternResolver);

            _mockRepo = new MockCountryRepository();
        }

        [Fact]
        public void CanNotBeNullPenaltyInputModelThrowExceptionTest()
        { 
            Assert.Throws<Exception>(()=>penaltyCalculationProcessor.Process(null));
        }

        [Fact]
        public void TurkeyPenaltyCalculationServiceTest()
        {
            Country country = _mockRepo.GetCountryById(1);
            _inputModel.Country = country;

            var _outputModel= penaltyCalculationProcessor.Process(_inputModel);
            var _expected = new PenaltyOutputModel() { BusinessDays = 4, TotalPrice = 0, CurrencySymbol = "₺" };

            Assert.NotNull(_outputModel);
          
            Assert.Equal(_expected.BusinessDays,_outputModel.BusinessDays);
            Assert.Equal(_expected.TotalPrice,_outputModel.TotalPrice);
            Assert.Equal(_expected.CurrencySymbol,_outputModel.CurrencySymbol);
        }

        [Fact]
        public void UnitedArabEmiratesPenaltyCalculationServiceTest()
        {
            Country country = _mockRepo.GetCountryById(2);
            _inputModel.Country = country;
           
            var _outputModel = penaltyCalculationProcessor.Process(_inputModel);
            var _expected = new PenaltyOutputModel() { BusinessDays = 6, TotalPrice = 0, CurrencySymbol = "د.إ.‏" };

            Assert.NotNull(_outputModel);

            Assert.Equal(_expected.BusinessDays, _outputModel.BusinessDays);
            Assert.Equal(_expected.TotalPrice, _outputModel.TotalPrice);
            Assert.Equal(_expected.CurrencySymbol, _outputModel.CurrencySymbol);
        }
    }
}
