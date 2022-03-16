using CSharpSelFramework.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using CSharpSelFramework.pageObjects;



// se instalaron selenium, webdriver, selenium extras, selenium web driver manager, selenium support
namespace CSharpSelFramework
{
    public class Tests : Base {

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void EndToEndFlow()
        {
            String[] ExpectedProducts = { "iphone X", "Blackberry" };

            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.getUserName().SendKeys("rahulshettyacademy");

            /*driver.FindElement(By.CssSelector("#username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.CssSelector("#password")).SendKeys("learning");
            driver.FindElement(By.CssSelector("#signInBtn")).Click();
            By signInBtn = By.CssSelector("#signInBtn");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.InvisibilityOfElementLocated(signInBtn));
            IList<IWebElement> products = driver.FindElements(By.CssSelector("app-card"));

            foreach (IWebElement product in products)
            {
                if (ExpectedProducts
                    .Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector("button")).Click(); // scope
                }
            }

            driver.FindElement(By.CssSelector(".nav-link.btn")).Click();

            IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));

            String[] actualProduct = new String[2];

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProduct[i] = checkoutCards[i].Text;
            }

            Assert.AreEqual(ExpectedProducts, actualProduct);

            driver.FindElement(By.CssSelector(".btn-success")).Click();
            driver.FindElement(By.CssSelector("#country")).SendKeys("ind");
            By country = By.LinkText("India");
            wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.ElementToBeClickable(country));
            driver.FindElement(country).Click();
            //wait.Until(SeleniumExtras.WaitHelpers
            //    .ExpectedConditions.ElementToBeClickable(By.CssSelector("#checkbox2")));
            driver.FindElement(By.CssSelector("[for='checkbox2']")).Click();
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            String expectedMessage = "Success!";
            String actualMessage = driver.FindElement(By.CssSelector("strong")).Text;
            StringAssert.Contains(expectedMessage, actualMessage);*/
        }
            
    }
}