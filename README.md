Web API services (built on NET Core 2.2) consuming the response from Wooliesx api's and returning responses based on the challenge.

The API is hosted on Azure and is publicly available
Azure swagger url: http://wooliesxapichallenge.azurewebsites.net/swagger/index.html

Git hub url: https://github.com/Bharu2705/WooliesX.TechChallenge

Solution can be run in Visual Studio 2017 

The project has the below structure. 

WoolisX.Model

Contains the domain classes to capture the response from the services

WooliesX.TechChallenge

Contains API with controllers (constructor DI for the services)

WooliesX.Service

Contains the actual service that’s consumes the response from Wooliesx api's and returning responses based on the challenge.

WooliesX.UnitTest

NSubstitute to test the controller and responses
Uses HttpMessageHandler for mocking httpClient request.

