using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitSeleniumLearning
{
    class E2ETest
    {
        IWebDriver driver;
        [SetUp]

        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(3);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void EndToEndFlow()
        {
            String[] ExpectedProducts = { "iphone X","Blackberry" };
            driver.FindElement(By.CssSelector("#username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.CssSelector("#password")).SendKeys("learning");
            driver.FindElement(By.CssSelector("#signInBtn")).Click();
            By signInBtn= By.CssSelector("#signInBtn");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.InvisibilityOfElementLocated(signInBtn));
            IList<IWebElement> products=driver.FindElements(By.CssSelector("app-card"));
            
            foreach( IWebElement product in products)
            {
                TestContext.Progress.WriteLine(
                    product.FindElement(By.CssSelector(".card-title a")).Text);
            }
            
            //driver.FindElement(By.CssSelector(".nav-link.btn")).Click();

        }

    }
}
