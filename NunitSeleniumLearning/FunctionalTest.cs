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
    class FunctionalTest
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
        public void dropdown()
        {
            IWebElement dropdown =driver.FindElement(By.CssSelector("[data-style]"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            s.SelectByValue("stud"); // zero index is equal at the first option
            s.SelectByIndex(2);

            IList<IWebElement> rdos = driver.FindElements(By.CssSelector("[type='radio']"));
            
            foreach (IWebElement radioButton in rdos)
            {
                if(radioButton.GetAttribute("value").Equals("user"))
                {
                    radioButton.Click();
                }
                
            }
            
            

            driver.Close();

        }

    }
}
