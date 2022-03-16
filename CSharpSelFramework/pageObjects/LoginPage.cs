using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSelFramework.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Page Object Factory
        [FindsBy(How = How.CssSelector, Using = "#username")]
        private IWebElement username;

        public IWebElement getUserName()
        {
            return username;
        }

}

    
}
