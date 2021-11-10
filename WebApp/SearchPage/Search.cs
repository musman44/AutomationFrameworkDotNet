using System;
using AutomationFrameworkDotNet.Core.UI.Web;
using NUnit.Framework;

namespace AutomationFrameworkDotNet.WebApp.SearchPage
{
    class Search
    {
        /*
         * Description:
            |  This class contains the methods for entering data in the field(s) and hit search button
         */

        BusinessUtilsUI businessUtilsUi;
        UtilsLocators utilsLocators;

        public Search()
        {
            businessUtilsUi = new BusinessUtilsUI();
            utilsLocators = new UtilsLocators();
        }

        public void SearchHotel()
        {           

            try
            {
                businessUtilsUi.Write(utilsLocators.locationDropDown, "Sydney");
                businessUtilsUi.Write(utilsLocators.hotelDropDown, "Hotel Hervey");
                businessUtilsUi.Write(utilsLocators.roomTypeDropDown, "Standard");
                businessUtilsUi.Write(utilsLocators.noOfRoomDropDown, "2 - Two");
                businessUtilsUi.Write(utilsLocators.checkInDateTxt, "08/07/2021");
                businessUtilsUi.Write(utilsLocators.checkOutDateTxt, "09/07/2021");
                businessUtilsUi.Write(utilsLocators.adultPerRoomDropDown, "2 - Two");
                businessUtilsUi.Write(utilsLocators.childrenPerRoomDropDown, "2 - Two");
                businessUtilsUi.Click(utilsLocators.searchBtn);

                Assert.IsTrue(businessUtilsUi.IsElementVisible(utilsLocators.continueBtn));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in SearchHotel method -->" + e.Message);
                throw;
            }
        }

        public void ResetBtn()
        {
            try
            {
                businessUtilsUi.Click(utilsLocators.resetBtn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in ResetBtn method -->" + e.Message);
                throw;
            }
        }

        public void SearchBtn()
        {
            try
            {
                businessUtilsUi.Click(utilsLocators.searchBtn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in SearchBtn method -->" + e.Message);
                throw;
            }
        }

    }
}
