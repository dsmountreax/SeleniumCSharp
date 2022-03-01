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
    class Locators
    {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]

    public void LocatorsIdentification()
        {
            driver.FindElement(By.CssSelector("#username")).SendKeys("usuario");
            driver.FindElement(By.CssSelector("#password")).SendKeys("Contraseña");
            driver.FindElement(By.CssSelector("#terms")).Click();
            driver.FindElement(By.CssSelector("#signInBtn")).Click();
            Thread.Sleep(3000);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".alert")).Text);
            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttr=link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/#/documents-request";
            Assert.AreEqual(expectedUrl,hrefAttr);
            driver.Close();
        }


    }
}
