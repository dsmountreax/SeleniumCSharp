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
        [TestCase("rahulshettyacademy", "learning")]
        [TestCase("rahulshettyacademy", "learning")]
        public void EndToEndFlow(String username,String password)
        {
            String[] ExpectedProducts = { "iphone X", "Blackberry" };

            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productsPage=loginPage.validLogin(username,password);
            productsPage.waitForPageToDisplay();
            IList<IWebElement> products = productsPage.getCards();
            
            foreach (IWebElement product in products)
            {
                if (ExpectedProducts
                    .Contains(product.FindElement(productsPage.getcardTitle()).Text))
                {
                    product.FindElement(productsPage.getButton()).Click(); // scope
                }
            }

            CheckoutPage checkoutPage=productsPage.checkout();
            
            IList<IWebElement> checkoutCards = checkoutPage.getCheckoutCards();
            
            String[] actualProduct = new String[2];

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProduct[i] = checkoutCards[i].Text;
            }
            /*
            Assert.AreEqual(ExpectedProducts, actualProduct);

            driver.FindElement(By.CssSelector(".btn-success")).Click();
            checkoutPage.checkout();
            /*
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