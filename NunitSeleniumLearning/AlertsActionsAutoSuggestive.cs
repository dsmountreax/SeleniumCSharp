using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitSeleniumLearning
{
    class AlertsActionsAutoSuggestive
    {
        IWebDriver driver;
        [SetUp]

        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }

        [Test]
        public void testAlert()
        {
            driver.FindElement(By.CssSelector("#name")).SendKeys("Enrique");
            driver.FindElement(By.CssSelector("#confirmbtn")).Click();
            String alertText=driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept(); // Dismiss to cancel Send keys. 
            StringAssert.Contains("Enrique",alertText);
        }

        [Test]
        public void test_AutosuggestiveDropdowns()
        {
            driver.FindElement(By.CssSelector("#autocomplete")).SendKeys("ind");
            Thread.Sleep(3000);
            IList<IWebElement> options=driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach(IWebElement option in options)
            {
                if(option.Text.Equals("India"))// cuidado con Equals
                {
                    option.Click();
                
                }
            }

            TestContext.Progress
            .WriteLine(driver.FindElement(By.CssSelector("#autocomplete"))
            .GetAttribute("value"));
        }

    }
}
