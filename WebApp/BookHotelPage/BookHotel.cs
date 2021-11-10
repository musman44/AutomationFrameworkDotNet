using System;
using NUnit.Framework;
using AutomationFrameworkDotNet.Core.UI.Web;

namespace AutomationFrameworkDotNet.WebApp.BookHotelPage
{
    class BookHotel
    {
        /*
         * Description:
            |  This class contains the methods for entering data in the field(s) and hit Book now button
         */

        BusinessUtilsUI businessUtilsUi;
        UtilsLocators utilsLocators;

        public BookHotel()
        {
            businessUtilsUi = new BusinessUtilsUI();
            utilsLocators = new UtilsLocators();
        }

        public void BookHotelPage()
        {
            try
            {
                businessUtilsUi.Write(utilsLocators.fnameTxt, "Amir");
                businessUtilsUi.Write(utilsLocators.lnameTxt, "Emam");
                businessUtilsUi.Write(utilsLocators.addressTxt, "R-67/1, Bufferzone, North Nazimabad");
                businessUtilsUi.Write(utilsLocators.cCNoTxt, "12345678987654321");
                businessUtilsUi.Write(utilsLocators.cCTypeDropDown, "VISA");
                businessUtilsUi.Write(utilsLocators.expiryMonthDropDown, "June");
                businessUtilsUi.Write(utilsLocators.expiryYearDropDown, "2022");
                businessUtilsUi.Write(utilsLocators.cVVNoTxt, "1234");
                businessUtilsUi.Click(utilsLocators.bookNowBtn);

                //Assert.IsTrue(businessUtilsUi.IsElementVisible(utilsLocators.continueBtn));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in SelectHotel method -->" + e.Message);
                throw;
            }
        }

        public void BookNowBtn()
        {
            try
            {
                businessUtilsUi.Click(utilsLocators.bookNowBtn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in BookNowBtn method -->" + e.Message);
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

        public void GetOrderNo()
        {
            try
            {
                string GeneratedorderNo = businessUtilsUi.GetElementAttributeText(utilsLocators.orderNoTxt);                
                Assert.IsNotEmpty(GeneratedorderNo);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in GetOrderNo method -->" + e.Message);
                throw;
            }
        }
    }
}
