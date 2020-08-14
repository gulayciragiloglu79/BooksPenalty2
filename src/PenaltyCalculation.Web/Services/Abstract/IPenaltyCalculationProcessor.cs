using PenaltyCalculation.Web.Models;

namespace PenaltyCalculation.Web.Services.Abstract
{
    public interface IPenaltyCalculationProcessor
    {
        PenaltyOutputModel Process(PenaltyInputModel inputViewModel);
    }
}