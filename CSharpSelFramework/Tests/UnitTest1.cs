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
    //[Parallelizable(ParallelScope.Children)] // class level children are classes inside this class
    [Parallelizable(ParallelScope.Self)] // use to run many classes at the same level. it replaced
                                         //previous parallelscope
    public class Tests : Base {

        [Test,Category("Smoke")]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test, TestCaseSource("addTestDataConfig"),Category("Regression")]
        // in cmd in project folder. dotnet test CSharpSelFramework.csproj
        // dotnet test pathto.csproj KK(All tests)
        // dotnet test CSharpSelFramework.csproj --filter TestCategory=Smoke
        //[TestCase("rahulshettyacademy", "learning")] // se comenta en clase 47
        //[TestCase("rahulshettyacademy", "learning")] // se comenta en clase 47
        //[TestCaseSource("addTestDataConfig")] // se pueden unificar en un solo bracket como en la linea 29
        // run all data sets of the Test method in parallel
        // run all the test methods in one class parallel
        // run all test files in project parallel

        [Parallelizable(ParallelScope.All)] // all this combination in parallel // testcase level
        public void EndToEndFlow(String username,String password, String[] productos)
        {
            String[] ExpectedProducts = productos;

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
         
        public static IEnumerable<TestCaseData> addTestDataConfig()
        {
            yield return new TestCaseData(getDataParser()
                .extractData("username"), getDataParser().extractData("password")
                ,getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser()
                .extractData("username"), getDataParser().extractData("password")
                , getDataParser().extractDataArray("products"));
            yield return new TestCaseData(getDataParser()
                .extractData("username"), getDataParser().extractData("password")
                , getDataParser().extractDataArray("products"));
        }
    }
}