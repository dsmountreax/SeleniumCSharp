using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.pageObjects
{
    public class ProductsPage
    {
        IWebDriver driver;
        private By cardTitle = By.CssSelector(".card-title a");
        private By button = By.CssSelector("button");
        private By signInBtn = By.CssSelector("#signInBtn");
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // comentar varias lineas crtl + k + c
        //
        //   IList<IWebElement> products = driver.FindElements(By.CssSelector("app-card"));

        [FindsBy(How = How.CssSelector, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.CssSelector, Using = ".nav-link.btn")]
        private IWebElement checkOut;

        
        public void waitForPageToDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
               wait.Until(SeleniumExtras.WaitHelpers
                   .ExpectedConditions.InvisibilityOfElementLocated(signInBtn));
        }

        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public By getcardTitle()
        {
            return cardTitle;
        }

        public By getButton()
        {
            return button;
        }

        public CheckoutPage checkout()
        {
            checkOut.Click();
            return new CheckoutPage(driver); 
        }
    }
}
