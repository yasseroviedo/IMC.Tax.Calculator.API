using FluentAssertions;
using IMC.Tax.Calculator.API.Controllers;
using IMC.Tax.Gateway.MessagesModels.Requests;
using IMC.Tax.Gateway.MessagesModels.Responses;
using IMC.Tax.Gateway.Utils;
using IMC.Tax.Interfaces;
using IMC.Tax.Interfaces.Exceptions;
using IMC.Tax.Services.Factories;
using IMC.Tax.Services.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IMC.Tax.Calculator.API.IntegrationTest
{
    public class TaxCalculatorProviderTest
    {
        private readonly ITaxCalculatorProviderFactory _taxCalculatorProviderFactory;
        private readonly ITaxJarApi _taxJarApi;
        private readonly ITaxCalculatorProviderService _taxCalculatorProviderService;
        public TaxCalculatorProviderTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            using (var scope = appFactory.Services.CreateScope())
            {
                _taxCalculatorProviderFactory = scope.ServiceProvider.GetRequiredService<ITaxCalculatorProviderFactory>();
                _taxJarApi = scope.ServiceProvider.GetRequiredService<ITaxJarApi>();
                _taxCalculatorProviderService = scope.ServiceProvider.GetRequiredService<ITaxCalculatorProviderService>();
                var taxJarApi = scope.ServiceProvider.GetService(typeof(ITaxJarApi));
                _taxCalculatorProviderService = new TaxJarCalculatorProviderService((ITaxJarApi)taxJarApi);
            }
        }
        #region Get Tests
        [Fact]
        public async Task GetRatesForLocation_WithoutZip_Throw_ArgumentException()
        {
            ///Arrange
            var zipCode = "";
            var rateArea = new RateArea()
            {
                Street = "312 Hurricane Lane",
                City = "Williston",
                State = "VT",
                Country = "US"
            };

            ///Act
            Func<Task> action = async () => await _taxCalculatorProviderService.GetTaskRateForLocation(zipCode, rateArea);
            // Assert
            action.Should().Throw<ArgumentException>();
        }
        [Fact]
        public async Task GetRatesForLocation_Valid_ReturnsTrue()
        {
            ///Arrange
            var zipCode = "90404";
            var rateArea = new RateArea()
            {
                Street = "312 Hurricane Lane",
                City = "Williston",
                State = "VT",
                Country = "US"
            };
            var mockResponse = new RootRate()
            {
                rate = new Rate()
                {
                    City = "SANTA MONICA",
                    City_Rate = "0.0",
                    Combined_District_Rate = "0.03",
                    Combined_Rate = "0.1025",
                    Country = "US",
                    Country_Rate = "0.0",
                    County = "LOS ANGELES",
                    County_Rate = "0.01",
                    Freight_Taxable = false,
                    State = "CA",
                    State_Rate = "0.0625",
                    Zip = "90404"
                }
            };
            ///Act
            var response = await _taxCalculatorProviderService.GetTaskRateForLocation(zipCode, rateArea);
            //Assert
            response.Should().BeEquivalentTo(mockResponse, options =>
                                            options.RespectingDeclaredTypes());
        }

        [Fact]
        public async Task GetRatesForLocation_WithoutRightParams_Throw_RateForLocationException()
        {
            ///Arrange
            var zipCode = "90404";
            var rateArea = new RateArea()
            {
                Street = "312 Hurricane Lane",
                City = "",
                State = "VT",
                Country = ""
            };

            ///Act
            Func<Task> action = async () => await _taxCalculatorProviderService.GetTaskRateForLocation(zipCode, rateArea);
            // Assert
            action.Should().Throw<RateForLocationException>();

        }
        #endregion

        #region Post Tests

        [Fact]
        public async Task GetSalesTax_Valid_ReturnsTrue()
        {
            ///Arrange
            var order = new OrderRequest()
            {
                From_Country = "US",
                From_Zip = "07001",
                From_State = "NJ",
                To_Country = "US",
                To_Zip = "07446",
                To_State = "NJ",
                Amount = 16.50,
                Shipping = 1.5,
                Line_Items = new List<LineItemRequest>()
                 {
                    new LineItemRequest()
                    {
                        Quantity = 1,
                        Unit_Price = 15.0,
                        Product_Tax_Code = "31000"
                    }
                 }

            };
            RootTax mockResponse = MockingRootTax();
            ///Act
            var result = await _taxCalculatorProviderService.GetSalesTaxForAnOrderAsync(order);
            // Assert
            result.Should().BeEquivalentTo(mockResponse, options =>
                                            options.RespectingDeclaredTypes());
        }

        private static RootTax MockingRootTax()
        {
            var mockShipping = new Shipping()
            {
                City_Amount = 0.0F,
                City_Tax_Rate = 0.0F,
                City_Taxable_Amount = 0.0F,
                Combined_Tax_Rate = 0.06625F,
                County_Amount = 0.0F,
                County_Tax_Rate = 0.0F,
                County_Taxable_Amount = 0.0F,
                Special_District_Amount = 0.0F,
                Special_Tax_Rate = 0.0F,
                Special_Taxable_Amount = 0.0F,
                State_Amount = 0.1F,
                State_Sales_Tax_Rate = 0.06625F,
                State_Taxable_Amount = 1.5F,
                Tax_Collectable = 0.1F,
                Taxable_Amount = 1.5F
            };
            var mockLineItems = new Line_Items[]
            {
                new Line_Items()
                {
                    City_Amount = 0.0F,
                    City_Tax_Rate = 0.0F,
                    City_Taxable_Amount = 0.0F,
                    Combined_Tax_Rate = 0.06625F,
                    County_Amount = 0.0F,
                    County_Tax_Rate = 0.0F,
                    County_Taxable_Amount = 0.0F,
                    Id ="1",
                    Special_District_Amount = 0.0F,
                    Special_District_Taxable_Amount = 0.0F,
                    Special_Tax_Rate = 0.0F,
                    State_Amount = 0.99F,
                    State_Sales_Tax_Rate = 0.06625F,
                    State_Taxable_Amount = 15.0F,
                    Tax_Collectable  = 0.99F,
                    Taxable_Amount = 15.0F
                }
            };
            Breakdown mockBreakdown = new Breakdown()
            {
                City_Tax_Collectable = 0.0F,
                City_Tax_Rate = 0.0F,
                City_Taxable_Amount = 0.0F,
                Combined_Tax_Rate = 0.06625F,
                County_Tax_Collectable = 0.0F,
                County_Tax_Rate = 0.0F,
                County_Taxable_Amount = 0.0F,
                Special_District_Tax_Collectable = 0.0F,
                Special_District_Taxable_Amount = 0.0F,
                Special_Tax_Rate = 0.0F,
                State_Tax_Collectable = 1.09F,
                State_Tax_Rate = 0.06625F,
                State_Taxable_Amount = 16.5F,
                Tax_Collectable = 1.09F,
                Taxable_Amount = 16.5F
            };
            mockBreakdown.Shipping = mockShipping;
            mockBreakdown.Line_Items = mockLineItems;
            Jurisdictions mockJurisdictions = new Jurisdictions()
            {
                City = "RAMSEY",
                Country = "US",
                County = "BERGEN",
                State = "NJ"
            };
            var mockTax = new Gateway.MessagesModels.Responses.Tax()
            {
                Amount_To_Collect = 1.09F,
                Freight_Taxable = true,
                Has_Nexus = true,
                Order_Total_Amount = 16.5F,
                Rate = 0.06625F,
                Shipping = 1.5F,
                Tax_Source = "destination",
                Taxable_Amount = 16.5F
            };
            mockTax.Breakdown = mockBreakdown;
            mockTax.Jurisdictions = mockJurisdictions;
            var mockResponse = new RootTax();
            mockResponse.tax = mockTax;
            return mockResponse;
        }

        [Fact]
        public async Task GetSalesTax_NoCountry_ReturnsNull()
        {
            ///Arrange
            var order = new OrderRequest()
            {
                From_Country = "",
                From_Zip = "07001",
                From_State = "NJ",
                To_Country = "US",
                To_Zip = "07446",
                To_State = "NJ",
                Amount = 16.50,
                Shipping = 1.5,
                Line_Items = new List<LineItemRequest>()
                 {
                    new LineItemRequest()
                    {
                        Quantity = 1,
                        Unit_Price = 15.0,
                        Product_Tax_Code = "31000"
                    }
                 }

            };
            ///Act
            var response = await _taxCalculatorProviderService.GetSalesTaxForAnOrderAsync(order);
            // Assert
            response.tax.Should().BeNull();
        }

        #endregion
    }
}
