using NUnit.Framework;
using System;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace CSharpSelFramework.utilities
{
    public class Base {
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser(){

            // se importa el paquete de configuration manager

            String browserName=ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void InitBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}
