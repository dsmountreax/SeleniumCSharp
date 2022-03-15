using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitSeleniumLearning
{
    class WindowHandlers
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void WindowHandle()
        {
            String parentWindowId = driver.CurrentWindowHandle;
            driver.FindElement(By.CssSelector(".blinkingText")).Click();
            Assert.AreEqual(2, driver.WindowHandles.Count);
            String childWindowName = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindowName);
            String text = driver.FindElement(By.CssSelector(".red")).Text;
            TestContext.Progress.WriteLine(text);
            String[] splittedText=text.Split("at");
            String[] trimmedString=splittedText[1].Trim().Split(" ");
            String email = "mentor@rahulshettyacademy.com";
            Assert.AreEqual(email, trimmedString[0]);
            driver.SwitchTo().Window(parentWindowId);
            driver.FindElement(By.CssSelector("#username")).SendKeys(trimmedString[0]);

            

        }
    }
}
