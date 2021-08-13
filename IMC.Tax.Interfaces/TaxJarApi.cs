using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using IMC.Tax.Gateway.MessagesModels.Responses;
using IMC.Tax.Gateway.MessagesModels.Requests;
using IMC.Tax.Gateway.Utils;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using IMC.Tax.Interfaces.Exceptions;
using System.Net;
using Microsoft.Extensions.Logging;

namespace IMC.Tax.Interfaces
{
    public class TaxJarApi : ITaxJarApi
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string taxUrl = Constants.TaxCalculatorProviderNames.TaxJarClient;
        private readonly ILogger _logger;
        public string LogMessage { get; set; }

        public TaxJarApi(IHttpClientFactory httpClientFactory, ILoggerFactory logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger.CreateLogger("TaxJarApiLogger");
        }
        public async Task<RootTax> GetSalesTaxForAnOrderAsync(OrderRequest order)
        {
            RootTax rootTaxResult = new();
            try
            {
                using var httpClient = _httpClientFactory.CreateClient(taxUrl);
                var queryAddress = Constants.TaxCalculatorProviderNames.RatesSegment;
                string url = String.Concat(httpClient.BaseAddress, queryAddress);
                string orderJson = JsonConvert.SerializeObject(order);
                var content = new StringContent(orderJson, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responseMessage = httpClient.PostAsync(url, content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var stringRate = await responseMessage.Content.ReadAsStringAsync();
                    rootTaxResult = JsonConvert.DeserializeObject<RootTax>(stringRate);
                }
            }
            catch (HttpRequestException exNotFound) when (exNotFound.StatusCode == HttpStatusCode.NotFound)
            {
                LogException(exNotFound);
                throw new TaxesException(exNotFound.Message, exNotFound.InnerException, exNotFound.StatusCode);
            }
            catch (HttpRequestException exServiceUnavailable) when (exServiceUnavailable.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                LogException(exServiceUnavailable);
                throw new TaxesException(exServiceUnavailable.Message, exServiceUnavailable.InnerException, exServiceUnavailable.StatusCode);
            }
            catch (HttpRequestException exNotAcceptable) when (exNotAcceptable.StatusCode == HttpStatusCode.NotAcceptable)
            {
                LogException(exNotAcceptable);
                throw new TaxesException(exNotAcceptable.Message, exNotAcceptable.InnerException, exNotAcceptable.StatusCode);
                //Logging
            }
            return rootTaxResult;
        }

        private void LogException(HttpRequestException ex)
        {
            LogMessage = $"{DateTime.UtcNow.ToLongTimeString()}-{ex.StatusCode}-{ex.Message}";
            _logger.LogError(LogMessage);
        }

        public async Task<RootRate> GetTaskRateForLocation(string zip, RateArea rateArea)
        {
            RootRate rootRateResult = new();
            try
            {
                using var httpClient = _httpClientFactory.CreateClient(taxUrl);
                StringBuilder queryAddress = new StringBuilder();
                queryAddress.AppendFormat(Constants.TaxCalculatorProviderNames.SalesSegment, zip, rateArea.Country, rateArea.City);
                string url = String.Concat(httpClient.BaseAddress, queryAddress.ToString());
                var responseMessage = await httpClient.GetStringAsync(url);
                rootRateResult = JsonConvert.DeserializeObject<RootRate>(responseMessage);
            }
            catch (HttpRequestException exNotFound) when (exNotFound.StatusCode == HttpStatusCode.NotFound)
            {
                LogException(exNotFound);
                throw new TaxesException(exNotFound.Message, exNotFound.InnerException, exNotFound.StatusCode);
            }
            catch (HttpRequestException exServiceUnavailable) when (exServiceUnavailable.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                LogException(exServiceUnavailable);
                throw new TaxesException(exServiceUnavailable.Message, exServiceUnavailable.InnerException, exServiceUnavailable.StatusCode);
            }
            catch (HttpRequestException exNotAcceptable) when (exNotAcceptable.StatusCode == HttpStatusCode.NotAcceptable)
            {
                LogException(exNotAcceptable);
                throw new RateForLocationException(exNotAcceptable.Message, exNotAcceptable.InnerException, exNotAcceptable.StatusCode);
                //Logging
            }
            return rootRateResult;
        }
    }
}
