using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitSeleniumLearning
{
    class SeleniumFirst {

        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //chromedriver.exe on chrome browser
            //WebDriverManager helps to download an manage the chromedriver
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig()); // Firefox configuration
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //driver = new ChromeDriver(); // invoke Chrome Browwser //IwebDriver is an interface
            //driver = new FirefoxDriver();  // Remember to import selenium for this driver
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/#/index";
            TestContext.Progress.WriteLine(driver.Title); // Write anything in the output
            TestContext.Progress.WriteLine(driver.Url);
            driver.Close(); // 1 Window
            //driver.Quit();  // 2 Window
        }
}
}
