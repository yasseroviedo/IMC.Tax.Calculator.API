using IMC.Tax.Services.Services;


namespace IMC.Tax.Services.Factories
{
    public interface ITaxCalculatorProviderFactory
    {
        ITaxCalculatorProviderService CreateTaxCalculatorProvider(string taxCalculatorProviderName);
    }
}
