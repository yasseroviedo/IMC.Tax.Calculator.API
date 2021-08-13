using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IMC.Tax.Gateway.MessagesModels.Responses;
using IMC.Tax.Gateway.Utils;
using IMC.Tax.Gateway.MessagesModels.Requests;

namespace IMC.Tax.Services.Services
{
    public interface ITaxCalculatorProviderService
    {
        Task<RootRate> GetTaskRateForLocation(string zip, RateArea rateArea);
        Task<RootTax> GetSalesTaxForAnOrderAsync(OrderRequest order);
    }
}
