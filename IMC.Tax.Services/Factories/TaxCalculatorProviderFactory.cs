
using IMC.Tax.Interfaces;
using IMC.Tax.Services.Services;
using System;


namespace IMC.Tax.Services.Factories
{
    public class TaxCalculatorProviderFactory : ITaxCalculatorProviderFactory
    {
        private  IServiceProvider _serviceProvider;
        public TaxCalculatorProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public ITaxCalculatorProviderService CreateTaxCalculatorProvider(string taxApiProviderName)
        {
            ITaxCalculatorProviderService taxCalculatorProviderService = null;
            const string TaxJar = nameof(TaxJar);
            switch (taxApiProviderName)
            {
                case TaxJar:
                    var taxJarApi = _serviceProvider.GetService(typeof(ITaxJarApi));
                    taxCalculatorProviderService = new TaxJarCalculatorProviderService((ITaxJarApi)taxJarApi);
                    break;
                default:
                    break;
            }

            return taxCalculatorProviderService;
        }

    }
}
