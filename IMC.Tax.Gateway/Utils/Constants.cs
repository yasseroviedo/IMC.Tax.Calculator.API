namespace IMC.Tax.Gateway.Utils
{
    public static class Constants
    {
        public static class TaxCalculatorProviderNames
        {
            public const string TaxJar = nameof(TaxJar);
            public const string TaxJarClient = nameof(TaxJarClient);
            public const string RatesSegment = "taxes";
            public const string SalesSegment = "rates/{0}?country={1}&city={2}";
        }
    }
}