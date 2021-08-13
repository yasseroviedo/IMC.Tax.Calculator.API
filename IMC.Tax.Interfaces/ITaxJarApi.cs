
using System.Threading.Tasks;
using IMC.Tax.Gateway.MessagesModels.Responses;
using IMC.Tax.Gateway.MessagesModels.Requests;
using IMC.Tax.Gateway.Utils;

namespace IMC.Tax.Interfaces
{
    public interface ITaxJarApi
    {
        Task<RootRate> GetTaskRateForLocation(string zip, RateArea rateArea);
        Task<RootTax> GetSalesTaxForAnOrderAsync(OrderRequest order);
    }
}
