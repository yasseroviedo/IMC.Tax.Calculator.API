using IMC.Tax.Services.Factories;
using IMC.Tax.Gateway.MessagesModels.Responses;
using IMC.Tax.Gateway.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IMC.Tax.Gateway.MessagesModels.Requests;

namespace IMC.Tax.Calculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ITaxCalculatorProviderFactory _taxCalculatorProviderFactory;

        public TaxCalculatorController(ITaxCalculatorProviderFactory taxCalculatorProviderFactory)
        {
            _taxCalculatorProviderFactory = taxCalculatorProviderFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetRates()
        {
            var rateArea = new RateArea()
            {
                Street = "312 Hurricane Lane",
                City = "Williston",
                State = "VT",
                Country = "US"
            };

            var taxCalculatorProvider = _taxCalculatorProviderFactory.CreateTaxCalculatorProvider(Constants.TaxCalculatorProviderNames.TaxJar);

            var response = await taxCalculatorProvider.GetTaskRateForLocation("90404", rateArea);

            return (response != null) ? Ok(response) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> GetSales([FromBody] OrderRequest order)
        {
            var taxCalculatorProvider = _taxCalculatorProviderFactory.CreateTaxCalculatorProvider(Constants.TaxCalculatorProviderNames.TaxJar);

            var response = await taxCalculatorProvider.GetSalesTaxForAnOrderAsync(order);

            return (response != null) ? Ok(response) : NotFound();
        }
    }
}
