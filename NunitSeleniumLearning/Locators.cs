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
            driver.FindElement(By.CssSelector("#signInBtn")).Click();
            driver.Close();
        }


    }
}
