# IMC.Tax.Calculator.API
Used libraries has been added via NuGet
XUnit and Fluent Assertions were used for unitesting.

Main Project-->IMC.Tax.Calculator.API

Test Project-->IMC.Tax.Calculator.API.IntegrationTest

If Needed

  NuGet Package Manager > Package Manager Console simply run:

  dotnet restore



Assignment:

We use a lot of external services and API's to accommodate our customers' needs.  One of them is Tax calculation.  There are a lot of Tax calculation API’s out there and we need to be able to work with many of them via a common interface we define in a service class.
Your code test is to simply create a Tax Service that can take a Tax Calculator in the class initialization and return the total tax that needs to be collected.
We are going to use Tax Jar as one of our calculators.  You will need to write a .Net client to talk to their API, do not use theirs.  Can be very simple, needed methods outlined below.

We are only going to be talking to their SalesTax API:
https://developers.taxjar.com/api/reference/#sales-tax-api
Here is the API Key:
5da2f821eee4035db4771edab942a4cc

The client you need to write for Tax Jar only needs to include a couple of methods:
•	Get the Tax rates for a location
•	Calculate the taxes for an order

The Tax Service will also have these methods and simply call the Tax Calculator.  Eventually we would have several Tax Calculators and the Tax Service would need to decide which to use based on the Customer that is consuming the Tax Service. 
Unit Tests on the Tax Jar calculator and Tax Service should be included in your solution.
