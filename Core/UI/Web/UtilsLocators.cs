using System;
using OpenQA.Selenium;

namespace AutomationFrameworkDotNet.Core.UI.Web
{
    public class UtilsLocators
    {
        /*
        * Description:
            |  This class contains locators which are related to Web UI Automation
        
        */

        #region Login Page Locators

        public By usernameTxt = By.XPath("//input[@name='username']");
        public By passwordTxt = By.XPath("//input[@name='password']"); 
        public By loginBtn = By.XPath("//input[@name='login']"); 
        public By welcomeTxt = By.XPath("//*[contains(text(),'Welcome')]");

        #endregion Login Page Locators 

        #region Search Page Locators

        public By locationDropDown = By.XPath("//select[@name='location']");
        public By hotelDropDown = By.XPath("//select[@name='hotels']"); 
        public By roomTypeDropDown = By.XPath("//select[@name='room_type']"); 
        public By noOfRoomDropDown = By.XPath("//select[@name='room_nos']"); 
        public By checkInDateTxt = By.XPath("//input[@name='datepick_in']");
        public By checkOutDateTxt = By.XPath("//input[@name='datepick_out']");
        public By adultPerRoomDropDown = By.XPath("//select[@name='adult_room']");
        public By childrenPerRoomDropDown = By.XPath("//select[@name='child_room']");
        public By searchBtn = By.XPath("//input[@name='Submit']");
        public By resetBtn = By.XPath("//input[@name='Reset']");

        #endregion Search Page Locators  

        #region Select Page Locators

        public By selectRadioBtn = By.XPath("//input[@name='radiobutton_0']");
        public By continueBtn = By.XPath("//input[@name='continue']");
        public By cancelBtn = By.XPath("//input[@name='cancel']");

        #endregion Select Page Locators

        #region Book Hotel Page Locators

        public By fnameTxt = By.XPath("//input[@name='first_name']");
        public By lnameTxt = By.XPath("//input[@name='last_name']");
        public By addressTxt = By.XPath("//textarea[@name='address']");
        public By cCNoTxt = By.XPath("//input[@name='cc_num']");
        public By cCTypeDropDown = By.XPath("//select[@name='cc_type']");
        public By expiryMonthDropDown = By.XPath("//select[@name='cc_exp_month']");
        public By expiryYearDropDown = By.XPath("//select[@name='cc_exp_year']");
        public By cVVNoTxt = By.XPath("//input[@name='cc_cvv']");
        public By bookNowBtn = By.XPath("//input[@name='book_now']");
        //public By cancelBtn = By.Id("cancel");
        public By orderNoTxt = By.XPath("//input[@name='order_no']");

        #endregion BookHotelPage Locators    

        //public string pstr_username = "//input[@name='username']";
        //public string pstr_password = "//input[@name='j_password']";
        //public string pstr_login_button = "//a[contains(text(),'Login')]";
        //public string locator_loggedin_check = ".//*[contains(text(),'Inspections') or contains(text(),'QAUser')]";
        //public string pstr_user_dropdown = "//button[contains(text(),'QAUser') or contains(@class,'ui-text-button ui-text-button--primary')]";
        //public string pstr_logout_button = ".//*[contains(text(),'Logout') or contains(text(),'Sign Out')]";
        //public string locator_logout_check = ".//*[contains(text(),'You have been logged out') or contains(text(),'Username or email')]";
        //public string locator_list_label_name = "//select[@name='<<text_replace>>']";
        //public string locator_option_name = "//option[text()='<<text_replace>>']";
        //public string pstr_searchbox = "//input[@name ='filterPrefix']";
        //public string pstr_link_text = "//a[text()='<<text_replace>>']";
        //public string pstr_button_text = "//a[text()='<<text_replace>>']";
        //public string pstr_toggle_arrow_button = "//input[@value='<<text_replace>>']";
        //public string locator_contains_text_xpath = "//*[contains(text(),'<<text_replace>>')]";
        //public string locator_inventoryinterfaceurl = "//input[@name='inventoryinterfaceurl']";
        //public string locator_inventoryinterfaceuser = "//input[@name='inventoryinterfaceuser']";
        //public string locator_inventoryinterfacepass = "//input[@name='inventoryinterfacepass']";
        //public string locator_companycode = "//input[@name='companycode']";
        //public string locator_saved_text = "//input[@value='<<text_replace>>']";
    }
}
