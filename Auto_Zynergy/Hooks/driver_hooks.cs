using Auto_Zynergy.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Zynergy.Hooks
{
    [Binding]
    class driver_hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private static IWebDriver driver = DriverClass.driver; // Use existing driver

        public driver_hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            if (DriverClass.driver == null)
            {
                DriverClass.driver = new ChromeDriver();
            }

            if (!_scenarioContext.ContainsKey("WebDriver"))
                _scenarioContext["WebDriver"] = DriverClass.driver;
        }

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    if (_scenarioContext.TryGetValue("WebDriver", out IWebDriver driver))
        //    {
        //        driver.Quit(); // Properly quit WebDriver after test
        //        DriverClass.driver = null; // Reset WebDriver reference
        //    }
        //}

        [AfterTestRun]
        public static void AfterTestRun()
        {
            if (DriverClass.driver != null)
            {
                DriverClass.driver.Quit(); // Final cleanup after all tests
                DriverClass.driver = null;
            }
        }



    }
}
