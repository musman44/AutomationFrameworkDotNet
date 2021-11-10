using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using AutomationFrameworkDotNet.Core.Initialization;

namespace AutomationFrameworkDotNet
{
    [Binding]
    public class TestExecution
    {
        /*
         * Description:
            |  This class contains the Initialization settings before and after the test cases are run
         */

        #region Setups and Cleanups
        //public TestContext instance;
        //public TestContext TestContext
        //{
        //    set { instance = value; }
        //    get { return instance; }
        //}

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            Initialization.ExecutionBrowser = ConfigurationManager.AppSettings["ExecutionBrowser"].ToString();
            Initialization.SeleniumInit();
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            Initialization.TestCleanup();
        }

        #endregion
    }
}
