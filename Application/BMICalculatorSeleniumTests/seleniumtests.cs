using BMICalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace BMICalculatorSeleniumTests
{
    [TestClass]
    public class seleniumtests
    {
        private static TestContext testContext;
        private RemoteWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            seleniumtests.testContext = testContext;
        }

        [TestInitialize]
        public void TestInit()
        {
            driver = GetChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TestCleanup]
        public void TestClean()
        {
            driver.Quit();
        }

        [TestMethod]
        [Obsolete]
        public void SampleFunctionalTest1()
        {
            var webAppUrl = "";
            try
            {
                webAppUrl = testContext.Properties["webAppUrl"].ToString();
            }
            catch (Exception)
            {
                webAppUrl = "http://localhost:50433/";
            }
            //var webAppUrl = testContext.Properties["webAppUrl"].ToString();

           // var startTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            //var endTimestamp = startTimestamp + 60 * 10;
            
            //Arrange     
            
            BMI bmi = new BMI() { WeightStones = 15, WeightPounds = 4, HeightFeet = 5, HeightInches = 7 };

           // WebDriverWait wait = new WebDriverWait(driver,( 20);

            driver.Navigate().GoToUrl(webAppUrl);
           // driver.Manage().Window.Size = new System.Drawing.Size(1052, 807);
            //driver.SwitchTo().DefaultContent();
            driver.FindElement(By.Id("WeightStones")).Click();
            driver.FindElement(By.Id("WeightStones")).SendKeys("15");
            driver.FindElement(By.Id("WeightPounds")).Click();
            driver.FindElement(By.Id("WeightPounds")).SendKeys("4");
            driver.FindElement(By.Id("HeightFeet")).Click();
            driver.FindElement(By.Id("HeightFeet")).SendKeys("5");
            driver.FindElement(By.Id("HeightInches")).Click();
            driver.FindElement(By.Id("HeightInches")).SendKeys("7");
            driver.FindElement(By.CssSelector(".btn")).Click();
            string actualvalue= driver.FindElement(By.Id("BMIValue")).Text;
            string actualcategory= driver.FindElement(By.Id("BMICategory")).Text;

            //Assert.AreEqual("Your BMI is " + bmi.BMIValue.ToString(), actualvalue);
            Assert.AreEqual("Bad Your BMI Category is " + BMICategory.Obese, actualcategory);
           // Assert.AreEqual(bmi.BMICategory, BMICategory.Obese);
        }

        private RemoteWebDriver GetChromeDriver()
        {
            var path = Environment.GetEnvironmentVariable("ChromeWebDriver");
            var options = new ChromeOptions();
            options.AddArguments("--no-sandbox");
           options.AddArguments("headless");

            if (!string.IsNullOrWhiteSpace(path))
            {
                return new ChromeDriver(path, options, TimeSpan.FromSeconds(300));
            }
            else
            {
                return new ChromeDriver(options);
            }
        }
    }
}