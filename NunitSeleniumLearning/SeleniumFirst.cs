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
    class SeleniumFirst {

        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //chromedriver.exe on chrome browser
            //WebDriverManager helps to download an manage the chromedriver
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(); // invoke Chrome Browwser //IwebDriver is an interface
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/#/index";

        }
}
}
