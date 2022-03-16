using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace CSharpSelFramework.pageObjects
{
    public class CheckoutPage
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "app-card")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutButton;

        [FindsBy(How = How.CssSelector, Using = "#country")]
        private IWebElement country;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public IList<IWebElement> getCheckoutCards()
        {
            return checkoutCards;
        }

        public void checkout()
        {
            checkoutButton.Click();
        }


    }
}