using System;
using TechTalk.SpecFlow;
using AutomationFrameworkDotNet.Services;

namespace AutomationFrameworkDotNet.Tests.Steps
{
    [Binding]
    public class ApiSteps
    {
        private Service service = new Service();

        [When(@"User hits service '(.*)'")]
        public void UserHitsService(string serviceName)
        {
            service.CreateAndCallServiceRequest(serviceName);
        }

        [Then(@"User can see status code is (.*)")]
        public void UserCanSeeStatusCode(int statusCode)
        {
            service.VerifyStatusCode(statusCode);
        }

        [Then(@"User validates that the response contains city name '(.*)'")]
        public void UserValidatesTheCityInResponse(string cityName)
        {
            service.VerifyResponseContent(cityName);
        }

        [Then(@"User validates that the response contains user name '(.*)'")]
        public void UserValidatesTheUserNameInResponse(string userName)
        {
            service.VerifyResponseContent(userName);
        }
    }
}
