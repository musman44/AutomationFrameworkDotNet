using System;
using System.Configuration;
using System.Data.SqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using AutomationFrameworkDotNet.Core.UI.Web;
using TechTalk.SpecFlow;

namespace AutomationFrameworkDotNet.Core.Initialization
{
    public class Initialization : BusinessUtilsUI
    {
        /*
         * Description:
            |  This class contains the methods for following;
            |  Browser instance initialization based on parameter set in config file
            |  Browser shutdown
            |  Mobile/android initialization based on parameter set in config file
            |  MS Sql connection establishment based on parameter set in config file
            |  MS Sql connection shutdown
         */

        #region Properties
        public static string host = ConfigurationManager.AppSettings["Host"].ToString();
        public static string port = ConfigurationManager.AppSettings["Port"].ToString();
        public static string serviceName = ConfigurationManager.AppSettings["ServiceName"].ToString();
        public static string dbUser = ConfigurationManager.AppSettings["DBUserName"].ToString();
        public static string dbPass = ConfigurationManager.AppSettings["DBPassword"].ToString();

        public static string connectionString = ConfigurationManager.AppSettings["MSSqlConnectString"].ToString();

        public static SqlConnection MSSQLConnection { get; set; }

        #endregion

        #region Android Device Properties
        public static string DeviceName = ConfigurationManager.AppSettings["DeviceName"].ToString();
        public static string Platform = ConfigurationManager.AppSettings["Platform"].ToString();
        public static string Version = ConfigurationManager.AppSettings["Version"].ToString();
        public static string DeviceBrowser = ConfigurationManager.AppSettings["DeviceBrowser"].ToString();
        public static string UDID = ConfigurationManager.AppSettings["UDID"].ToString();
        public static string AppPackage = ConfigurationManager.AppSettings["AppPackage"].ToString();
        public static string AppActivity = ConfigurationManager.AppSettings["AppActivity"].ToString();
        #endregion        

        #region SELENIUM CONNECTION
        public static void SeleniumInit()
        {

            #region Edge
            if (ExecutionBrowser == Browser.MicrosoftEdge)
            {
                try
                {
                    //var options = new OpenQA.Selenium.Edge.EdgeOptions();
                    //var service = EdgeDriverService.CreateDefaultService(@"D:\Automation\Assignments\AutomationFrameworkDotNet\bin\Debug\", @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
                    //service.Start();

                    //// For future reference - please check to see if there are options that should be set...

                    //driver = new RemoteWebDriver(service.ServiceUrl, options);
                                                           
                    driver = new EdgeDriver();

                }
                catch (Exception ex)
                {
                }

            }
            #endregion

            #region IE
            else if (ExecutionBrowser == Browser.IE)
            {


            }
            #endregion

            #region Firefox
            else if (ExecutionBrowser == Browser.FireFox)
            {

                if (HeadlessExecution)
                {
                    FirefoxOptions options = new FirefoxOptions();
                    options.AddArguments("--headless");
                    driver = new FirefoxDriver(options);

                }
                else
                {
                    driver = new FirefoxDriver();
                }
            }
            #endregion

            #region Chrome
            else if (ExecutionBrowser == Browser.Chrome)
            {
                try
                {
                    if (HeadlessExecution == true)
                    {
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("headless");
                        chromeOptions.AddArguments("--incognito");
                        chromeOptions.AddArgument("--start-maximized");
                        driver = new ChromeDriver(chromeOptions);
                    }
                    else
                    {
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--incognito");
                        chromeOptions.AddArgument("--start-maximized");
                        driver = new ChromeDriver(chromeOptions);                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in driver Initialization -->" + ex.Message);
                }
            }
            #endregion

            #region Android
            else if (ExecutionBrowser == Browser.Android)
            {
                AppiumOptions capabilities = new AppiumOptions();
                capabilities.AddAdditionalCapability(Keywords.DeviceName, DeviceName);
                capabilities.AddAdditionalCapability(Keywords.Udid, UDID);
                capabilities.AddAdditionalCapability(Keywords.PlatformVersion, Version);
                capabilities.AddAdditionalCapability(Keywords.PlatformName, Platform);
                if (DeviceBrowser != string.Empty)
                {
                    capabilities.AddAdditionalCapability(Keywords.BrowserName, DeviceBrowser);
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.UseSpecCompliantProtocol = false;
                    capabilities.GetMergeResult(chromeOptions);
                }
                else
                {
                    capabilities.AddAdditionalCapability(Keywords.AppPackage, AppPackage);
                    capabilities.AddAdditionalCapability(Keywords.AppActivity, AppActivity);
                }
                //Wait for 2 minutes for driver to load
                driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(MaxTimeToFindElement));
                //NOTE: this android chrome driver is not locating elements by id, but xpath and css locators are working
            }
            #endregion

        }

        public static void CloseSelenium()
        {
            driver.Close();
            driver.Dispose();
            driver.Quit();
        }
        #endregion

        #region MSSQL CONNECTION
        public static SqlConnection MSSQLConnect()
        {
            //string connectionString = null;
            SqlConnection connection;
            // connectionString = @"Data Source="+host+";Initial Catalog="+dbName+"; Integrated Security=SSPI; User ID="+dbUser+"; Password="+dbPass;
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                // MessageBox.Show("Cannot open Database Connection(MSSQL)! " + ex);
            }

            return connection;
        }
        public static void CloseSQLDBConnection(SqlConnection conn)
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        
        /// <summary>
        /// 1. Install JDK 8 and set Environemnt Variables (JAVA_HOME>Path of JDK, Path>JDK bin Path; ANDROID_HOME> sdk path)
        /// 2. Install Android Studio
        /// 3. Install Appium
        /// 4. Create a virtual device using Andoird Device Manager(Android Sudio>Tool>AVD Manager)
        /// 5. power shell > adb devices
        /// </summary>
        public static void AndroidConnection()
        {

        }

        public static void TestCleanup()
        {
            driver.Quit();
        }
    }
}
