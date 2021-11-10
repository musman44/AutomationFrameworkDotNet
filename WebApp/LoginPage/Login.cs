using System;
using NUnit.Framework;
using AutomationFrameworkDotNet.Core.UI.Web;
using System.Configuration;

namespace AutomationFrameworkDotNet.WebApp.LoginPage
{
    class Login
    {
        /*
         * Description:
            |  This class contains the methods for website Login & Logout using the URL, id & pwd mentioned in config file
         */
        public static string Url = ConfigurationManager.AppSettings["Url"].ToString();
        public static string LoginUser = ConfigurationManager.AppSettings["LoginUser"].ToString();
        public static string LoginPassword = ConfigurationManager.AppSettings["LoginPassword"].ToString();

        BusinessUtilsUI businessUtilsUi;
        UtilsLocators utilsLocators;

        public Login()
        {
            businessUtilsUi = new BusinessUtilsUI();
            utilsLocators = new UtilsLocators();
        }

        public void SiteLogin()
        {
            // Login to the mentioned site using steps involved           

            try
            {                
                businessUtilsUi.OpenUrl(Url);
                businessUtilsUi.Write(utilsLocators.usernameTxt, LoginUser);
                businessUtilsUi.Write(utilsLocators.passwordTxt, LoginPassword);
                businessUtilsUi.Click(utilsLocators.loginBtn);

                Assert.IsTrue(businessUtilsUi.IsElementVisible(utilsLocators.welcomeTxt));                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in SiteLogin method -->" + e.Message);
                throw;
            }
        }

        public void SiteLogout()
        {
            // Logout from current site using common CSBusinessUtilsUI > Logout method           

            try
            {
                //Assert.IsTrue(businessUtilsUi.Logout());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in SiteLogout method -->" + e.Message);
                throw;
            }

        }
    }
}
