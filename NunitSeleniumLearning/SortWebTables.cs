using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitSeleniumLearning
{
    class SortWebTables
    {
        IWebDriver driver;
        [SetUp]

        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void SortTable()
        {
            ArrayList names = new ArrayList();
            IWebElement dropdown = driver.FindElement(By.CssSelector("#page-menu"));
            
            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("20");
            IList<IWebElement> veggies = driver.FindElements(By.CssSelector("tr td:nth-child(1)"));
            
            foreach (IWebElement veggie in veggies)
            {
                names.Add(veggie.Text);
            }

            foreach (String name in names)
            {
                TestContext.Progress.WriteLine(name);
            }

            names.Sort();

            foreach(String name in names)
            {
                TestContext.Progress.WriteLine(name);
            }
            /*
            driver.FindElement(By.CssSelector("thead th:nth-child(1)")).Click();
            ArrayList namesB = new ArrayList();
            foreach (IWebElement VegFruitName in veggies)
            {
                namesB.Add(VegFruitName.Text);
            }*/
        }

    }
}
