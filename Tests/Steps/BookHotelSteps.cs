using System;
using System.Threading;
using TechTalk.SpecFlow;
using AutomationFrameworkDotNet.WebApp.LoginPage;
using AutomationFrameworkDotNet.WebApp.SearchPage;
using AutomationFrameworkDotNet.WebApp.SelectPage;
using AutomationFrameworkDotNet.WebApp.BookHotelPage;

namespace AutomationFrameworkDotNet.Tests.Steps
{
    [Binding]
    public class BookHotelSteps
    {
        private Login login = new Login();
        private Search search = new Search();
        private Select select = new Select();
        private BookHotel bookHotel = new BookHotel();

        [Given(@"User is logged in to the site")]
        public void GivenUserIsLoggedInToSite()
        {
            login.SiteLogin();
        }
        
        [When(@"User searches for a hotel of his desire")]
        public void SearchAHotel()
        {
            search.SearchHotel();
        }
        
        [When(@"User selects a hotel from the search results")]
        public void SelectHotelFromTheSearchResults()
        {
            select.SelectHotel();
        }
        
        [Then(@"User books a hotel")]
        public void BookHotel()
        {
            bookHotel.BookHotelPage();
            Thread.Sleep(10000);            
        }
        
        [Then(@"User can see hotel is booked successfully and order no is generated")]
        public void HotelBookedSuccessfully()
        {
            bookHotel.GetOrderNo();
        }
    }
}
