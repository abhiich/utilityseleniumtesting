using System;
using Auto_Zynergy.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Reqnroll;
using OtpNet;
using Auto_Zynergy.Drivers;

namespace Auto_Zynergy.StepDefinitions.Main
{
    [Binding]
    public class LoginWithTwoFactorIntoZynergyStepDefinitions
    {

        Secrets secrets = new Secrets();
        public WebDriverWait wait;
        public WebDriverWait wait1;

        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;

        [Given("I am on the microsoft login page")]
        public void GivenIAmOnTheMicrosoftLoginPage()
        {

            _driver.Navigate().GoToUrl(secrets.test_url);
            _driver.Manage().Window.Maximize();
          
            }

            [Given("I enter my email address")]
        public void GivenIEnterMyEmailAddress()
        {
           // wait.Until(drv => drv.FindElement(By.Name("loginfmt"))).SendKeys(secrets.email);
            //    wait.Until(drv => drv.FindElement(By.Id("idSIButton9"))).Click();
            //    //wait.Until(drv => drv.FindElement(By.Id("signInAnotherWay"))).Click();
            //    Thread.Sleep(2000);
            
        }

        [Given("I enter the OTP")]
        public void GivenIEnterTheOTP()
        {
            var GeneratedOtp = OTP(secrets.secretKey);
            Thread.Sleep(2000);
            wait.Until(drv => drv.FindElement(By.Name("otc"))).SendKeys(GeneratedOtp);
        }

        [Given("I should be logged into Zynergy")]
        public void GivenIShouldBeLoggedIntoZynergy()
        {
            Thread.Sleep(2000);
            wait.Until(drv => drv.FindElement(By.Id("idSubmit_SAOTCC_Continue"))).Click();
            wait1.Until(drv => drv.FindElement(By.XPath("//h2[text()='Batch']")));
        }


        public LoginWithTwoFactorIntoZynergyStepDefinitions(ScenarioContext scenarioContext)
        {
            wait = new WebDriverWait(DriverClass.driver, TimeSpan.FromSeconds(10));
            wait1 = new WebDriverWait(DriverClass.driver, TimeSpan.FromSeconds(200));
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext["WebDriver"] as IWebDriver;
        }

        public LoginWithTwoFactorIntoZynergyStepDefinitions()
        {
        }

        public string OTP(string secretkey)
        {

            var otp = new Totp(Base32Encoding.ToBytes(secretkey));
            string otpCode = otp.ComputeTotp();
            return otpCode;
        }
    }
}
