using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PenaltyCalculation.Web.Data;
using PenaltyCalculation.Web.Models;
using PenaltyCalculation.Web.Services;
using PenaltyCalculation.Web.Services.Abstract;

namespace PenaltyCalculation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IPenaltyCalculationProcessor _penaltyCalculationProcessor;

        public HomeController(ICountryRepository countryRepository , IPenaltyCalculationProcessor penaltyCalculationProcessor)
        {
            _countryRepository = countryRepository;
            _penaltyCalculationProcessor = penaltyCalculationProcessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            setDropDownListForCountry();
            
            ViewBag.ShowResult = false;

            return View();
        }

        [HttpPost]
        public IActionResult Index(PenaltyInputModel model)
        {
            setDropDownListForCountry();

            if (ModelState.IsValid)
            {
                var _country = _countryRepository.GetCountryById(model.Country.CountryId);
                model.Country = _country;

                var item = _penaltyCalculationProcessor.Process(model);

                if (item != null)
                {                   
                    ViewBag.BusinessDays = item.BusinessDays;
                    ViewBag.Penalty = item.TotalPrice;
                    ViewBag.CurrencySymbol = item.CurrencySymbol;
                    ViewBag.ShowResult = true;
                }
                return View(model);
            }
            return View(model);
        }

        private void setDropDownListForCountry()
        {
            var _countryList = _countryRepository.AllCountries.ToList();
            ViewBag.countryList = _countryList;
        }
    }
}
