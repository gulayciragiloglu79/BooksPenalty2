using PenaltyCalculation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Web.Services.Abstract
{
    public interface IPenaltyCalculationService
    {
        dynamic Calculate(int penaltyDays, string currency);
        int GetBusinessDays(PenaltyInputModel inputModel);
    }
}
