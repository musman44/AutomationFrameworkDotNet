using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFrameworkDotNet.Core.UI.Web
{
    public class BusinessUtilsUI
    {
        /*
         * Description:
            |  This class contains the common methods or utilities for Web UI Automation
         */

        #region Properties
        public static dynamic driver;
        public static int MaxTimeToFindElement = Convert.ToInt32(ConfigurationManager.AppSettings["MaxTimeToFindElement"]);
        public static string ExecutionBrowser = ConfigurationManager.AppSettings["ExecutionBrowser"].ToString();
        public static bool HeadlessExecution = Convert.ToBoolean(ConfigurationManager.AppSettings["HeadlessExecution"]);

        public UtilsLocators utilsLocators;

        #endregion

        public BusinessUtilsUI()
        {
            //driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
            utilsLocators = new UtilsLocators();
        }

        #region Core Methods
        
        public void OpenUrl(string url)
        {
            try 
            {
                driver.Url = url;
            }
            catch (Exception ex)
            {

            }
        }

        public void Write(By by, string setValue, int timeToReadyElement = 0)
        {
            try // Locate Element
            {
                var element = WaitforElement(by, timeToReadyElement);
                element.SendKeys(setValue);
            }
            catch (Exception ex)
            {

            }
        }
        public void Click(By by, int timeToReadyElement = 0)
        {
            try // Locate Element
            {
                var element = WaitforElement(by, timeToReadyElement);
                element.Click();

            }
            catch (Exception ex) // Element Not found
            {

            }
        }
        
        public string GetElementText(By by)
        {
            string text;
            try
            {
                text = driver.FindElement(by).Text;
            }
            catch
            {
                try
                {
                    text = driver.FindElement(by).GetAttribute("value");
                }
                catch
                {
                    text = driver.FindElement(by).GetAttribute("innerHTML");
                }
            }
            return text;
        }
        public bool GetElementState()
        {
            return true;
        }
        public string GetElementAttributeText(By by, int timeToReadyElement = 1)
        {
            string actualValue = string.Empty;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                if (IsElementPresent(by))
                {
                    if (IsElementTextField(by) == true)
                    {
                        actualValue = WaitforElement(by, timeToReadyElement).GetAttribute("value");
                    }
                    else
                    {
                        actualValue = WaitforElement(by, timeToReadyElement).GetAttribute("text");
                        if (actualValue == null || actualValue == String.Empty)
                        {
                            actualValue = WaitforElement(by, timeToReadyElement).GetAttribute("innerHTML");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return actualValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public bool IsElementVisible(By by)
        {
            if (driver.FindElement(by).Displayed || driver.FindElement(by).Enabled)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

        #endregion


        #region Private Methods       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool IsElementTextField(By by)
        {
            try
            {
                bool resultText = Convert.ToBoolean(driver.FindElement(by).GetAttribute("type").Equals("text"));
                bool resultPass = Convert.ToBoolean(driver.FindElement(by).GetAttribute("type").Equals("password"));
                if (resultText == true || resultPass == true)
                { return true; }
                else
                { return false; }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeToReadyElement"></param>
        /// <returns></returns>
        private IWebElement WaitforElement(By by, int timeToReadyElement = 0)
        {
            IWebElement element = null;
            try
            {
                if (timeToReadyElement != 0 && timeToReadyElement.ToString() != null)
                {
                    PlaybackWait(timeToReadyElement * 1000);
                }

                element = driver.FindElement(by);
            }
            catch
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(MaxTimeToFindElement));
                wait.Until(driver => IsPageReady(driver) == true && IsElementVisible(by) == true && IsClickable(by) == true);
                element = driver.FindElement(by);
            }
            return element;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        private bool IsPageReady(IWebDriver driver)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool IsClickable(By by)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion

        #region Utility Methods
        
        public static void PlaybackWait(int miliSeconds)
        {
            Thread.Sleep(miliSeconds);
        }       
        #endregion






        //public Boolean IsExpectedTextOnPageDisplayed(string text)
        //{
        //    /*
        //     * Description:
        //        |   This method is used to verify any text/information on CS pages
        //     */

        //    try
        //    {
        //        string pstr_expected_text_value = (utilsLocators.locator_contains_text_xpath).Replace("<<text_replace>>", text);
        //        IWebElement expected_text_element = driver.FindElement(By.XPath(pstr_expected_text_value));

        //        if (expected_text_element != null)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error in IsExpectedTextOnPageDisplayed method -->" + e.Message);
        //        return false;
        //    }

        //}

        //public void SingleSelectDropdown(string option, string label, string explicitWait = null)
        //{
        //    /*
        //     * Description:
        //        |   This method is used to select the particular value (option) from single select drop down 
        //        |   The dropdown label name must be provided by the user in the calling method e.g., jump
        //     */

        //    try
        //    {
        //        string locator_list_label_name = (utilsLocators.locator_list_label_name).Replace("<<text_replace>>", label);
        //        string locator_option_name = (utilsLocators.locator_option_name).Replace("<<text_replace>>", option);

        //        driver.FindElement(By.XPath(locator_list_label_name)).Click();
        //        driver.FindElement(By.XPath(locator_option_name)).Click();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message + "failed to select list option from drop down , option:" + option + " ; label: " + label);
        //        throw;
        //    }
        //}

        //public void CSSearch(string searchText)
        //{
        //    /*
        //     * Description:
        //        |   This method is used to search for the specific text which is entered in search box                  
        //     */

        //    try
        //    {
        //        driver.FindElement(By.XPath(utilsLocators.pstr_searchbox)).Click();
        //        driver.FindElement(By.XPath(utilsLocators.pstr_searchbox)).SendKeys(searchText);
        //        driver.FindElement(By.XPath(utilsLocators.pstr_searchbox)).SendKeys(Keys.Enter);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //}

        //public void CSClickLink(string linkText)
        //{
        //    /*
        //     * Description:
        //        |   This method is used to click on the specific link on the page
        //     */

        //    try
        //    {
        //        string locator_link_name = (utilsLocators.pstr_link_text).Replace("<<text_replace>>", linkText);
        //        driver.FindElement(By.XPath(locator_link_name)).Click();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error in CSClickLink method -->" + e.Message);
        //        throw;
        //    }
        //}

        //public void CSClickButton(string buttonText)
        //{
        //    /*
        //     * Description:
        //        |   This method is used to click on the specific button on the page
        //     */

        //    try
        //    {
        //        string locator_button_name = (utilsLocators.pstr_button_text).Replace("<<text_replace>>", buttonText);
        //        driver.FindElement(By.XPath(locator_button_name)).Click();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error in CSClickButton method -->" + e.Message);
        //        throw;
        //    }
        //}


        //public void CSEnterDataInTextbox(string textbox, string value)
        //{
        //    /*
        //     * Description:
        //        |   This method is used to enter value in the specific textbox on the page
        //     */

        //    try
        //    {
        //        driver.FindElement(By.XPath(textbox)).Click();
        //        driver.FindElement(By.XPath(textbox)).Clear();
        //        driver.FindElement(By.XPath(textbox)).SendKeys(value);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error in CSEnterDataInTextbox method -->" + e.Message);
        //        throw;
        //    }
        //}


        //public Boolean IsDataSaved(string text)
        //{
        //    /*
        //     * Description:
        //        |   This method is used to verify if provided text/information is available after save on CS pages
        //     */

        //    try
        //    {
        //        string pstr_expected_saved_value = (utilsLocators.locator_saved_text).Replace("<<text_replace>>", text);
        //        IWebElement expected_text_element = driver.FindElement(By.XPath(pstr_expected_saved_value));

        //        if (expected_text_element != null)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error in IsDataSaved method -->" + e.Message);
        //        return false;
        //    }

        //}
    }
}
