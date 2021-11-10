using System;
using NUnit.Framework;
using AutomationFrameworkDotNet.Core.UI.Web;

namespace AutomationFrameworkDotNet.WebApp.SelectPage
{
    class Select
    {
        /*
         * Description:
            |  This class contains the methods for selecting data from the grid and hit continue button
         */

        BusinessUtilsUI businessUtilsUi;
        UtilsLocators utilsLocators;

        public Select()
        {
            businessUtilsUi = new BusinessUtilsUI();
            utilsLocators = new UtilsLocators();
        }

        public void SelectHotel()
        {
            try
            {                
                businessUtilsUi.Click(utilsLocators.selectRadioBtn);
                businessUtilsUi.Click(utilsLocators.continueBtn);

                Assert.IsTrue(businessUtilsUi.IsElementVisible(utilsLocators.bookNowBtn));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in SelectHotel method -->" + e.Message);
                throw;
            }
        }

        public void ContinueBtn()
        {
            try
            {
                businessUtilsUi.Click(utilsLocators.continueBtn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in ContinueBtn method -->" + e.Message);
                throw;
            }
        }

        public void CancelBtn()
        {
            try
            {
                businessUtilsUi.Click(utilsLocators.cancelBtn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in CancelBtn method -->" + e.Message);
                throw;
            }
        }
    }
}
