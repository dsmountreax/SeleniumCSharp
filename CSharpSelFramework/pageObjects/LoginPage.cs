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

        [FindsBy(How = How.CssSelector, Using = "#password")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "#signInBtn")]
        private IWebElement signInButton;

        public IWebElement getSignInButton()
        {
            return signInButton;
        }

        public IWebElement getPassword()
        {
            return password;
        }


        /*
        driver.FindElement(By.CssSelector("#signInBtn")).Click();
        By signInBtn = By.CssSelector("#signInBtn");*/

        public IWebElement getUserName()
        {
            return username;
        }

        public void validLogin(string usuario, string contraseña)
        {
            username.SendKeys(usuario);
            password.SendKeys(contraseña);
            signInButton.Click();
            
        }

}

    
}
