using System;
using System.Threading.Tasks;
using IMC.Tax.Interfaces;
using IMC.Tax.Gateway.MessagesModels.Requests;
using IMC.Tax.Gateway.Utils;
using IMC.Tax.Gateway.MessagesModels.Responses;

namespace IMC.Tax.Services.Services
{
    public class TaxJarCalculatorProviderService : ITaxCalculatorProviderService
    {
        private readonly ITaxJarApi _taxJarApi;

        public TaxJarCalculatorProviderService(ITaxJarApi taxJarApi)
        {
            _taxJarApi = taxJarApi;
        }

        public async Task<RootRate> GetTaskRateForLocation(string zip, RateArea rateArea)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(zip))
                {
                    throw new ArgumentException("Have to enter a ZipCode");
                }

                return await _taxJarApi.GetTaskRateForLocation(zip, rateArea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RootTax> GetSalesTaxForAnOrderAsync(OrderRequest order)
        {
            try
            {
                return await _taxJarApi.GetSalesTaxForAnOrderAsync(order);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
