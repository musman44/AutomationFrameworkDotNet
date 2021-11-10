using System;

namespace AutomationFrameworkDotNet.Core.Initialization
{
    
    public static class Keywords
    {
        /*
         * Description:
            |  This class contains the Core Keywords used throughout the project
            |  Keywords are used inorder to avoid human errors
         */

        public static string DeviceName = "deviceName";
        public static string Udid = "udid";
        public static string PlatformVersion = "platformVersion";
        public static string PlatformName = "platformName";
        public static string BrowserName = "browserName";
        public static string AppPackage = "appPackage";
        public static string AppActivity = "appActivity";

        public static string Initiate = "Initiate";
        public static string Exception = "Exception";
        public static string Other = "Other";
        public static string Actual = "Actual";
        public static string Adjustment = "Adjustment";
        public static string Hold = "Hold";
        public static string Resume = "Resume";
        public static string Close = "Close";
        public static string Delete = "Delete";
        public static string Release = "Release";
        public static string Abort = "Abort";
        public static string Copy = "Copy";
        public static string Now = "Now";
        public static string enabled = "enabled";
        public static string disabled = "disabled";
        public static string Increase = "Increase";
        public static string Decrease = "Decrease";
        public static string USB = "USB";
        public static string Blackbox = "Blackbox";
        public static string Serial = "Serial";
        public static string ScrollToTop = "head";
        public static string ScrollToBottom = "body";
        public static string PASSED = "Passed";
        public static string FAILED = "Failed";
        public static string EXECUTED = "EXECUTED";
        public static string TestMethodEnd = "TestMethodEnd";
        public static string True = "true";
        public static string False = "false";
        public static string Disabled = "Disabled";
        public static string Enabled = "Enabled";
        public static string Checked = "checked";
        public static string type = "type";
        public static string text = "text";
        public static string value = "value";
        public static string Title = "Title";
        public static string Url = "Url";
        public static string Contains = "Contains";
        public static string AreEqual = "AreEqual";
    }
    public static class LogStatus
    {
        public static string PASSED = "Passed";
        public static string FAILED = "Failed";
        public static string INFO = "Info";
        public static string FATAL = "Fatal";
        public static string ERROR = "Error";
        public static string EXECUTED = "EXECUTED";
        public static string TESTMETHODEND = "TestMethodEnd";

    }
    public static class Browser
    {
        public static string Chrome = "Chrome";
        public static string FireFox = "FireFox";
        public static string IE = "IE";
        public static string MicrosoftEdge = "MicrosoftEdge";
        public static string Safari = "Safari";
        public static string Android = "Android";
        public static string IPad = "IPad";
    }
    public static class CoreKeyboardActions
    {
        public static string BackspaceKey = "{BS}";
        public static string ClearKey = "{CLEAR}";
        public static string TabKey = "{TAB}";
        public static string EnterKey = "~";
        public static string ESCKey = "{ESC}";
        public static string NumLockKey = "{NUMLOCK}";
    }
    public class MyDemoAppTestCategory
    {
        public const string BAT = "BAT";
        public const string Weekly = "Weekly";
        public const string Daily = "Daily";
        public const string Monthly = "Monthly";
        public const string Regression = "Regression";
        public const string General = "General";
        public const string Login = "Login";
        public const string InternalServerError = "InternalServerError";
        public const string WebAPI = "WebAPI";
        public const string NativeApp = "NativeApp";
        public const string MobileWebApp = "MobileWebApp";
        public const string Android = "Android";

    }
    public class MyDemoAppTester
    {
        public const string AmirImam = "Amir Imam";
        public const string WajeehaSiddiqui = "Wajeeha Siddiqui";

    }
    public class Messages
    {
        public const string InvalidLoginError = "Invalid Login details or Your Password might have expired. Click here to reset your password";
        public const string LoginSuccessMessage = "Welcome to Adactin Group of Hotels";
    }
}
