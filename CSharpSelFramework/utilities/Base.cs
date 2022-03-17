using NUnit.Framework;
using System;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using System.Threading;
using System.IO;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace CSharpSelFramework.utilities
{
    public class Base {

        ExtentReports extent;
        String browserName;
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath=projectDirectory + "//index.html";
            var htmlReporter=new ExtentHtmlReporter(reportPath);
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Rahul Sheety");
        }

        //public IWebDriver driver;// se comenta esta linea porque no es un driver para paralelo
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();// driver paralelo

        [SetUp]
        public void StartBrowser(){

            extent.CreateTest(TestContext.CurrentContext.Test.Name);
            // se importa el paquete de configuration manager
            //Configuration for cmd
            // comando a ejecutar dotnet test CSharpSelFramework.csproj
            // -- TestRunParameters.Parameter(name=\"browserName\",value=\"Firefox\")
            browserName = TestContext.Parameters["browserName"];
            if(browserName==null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            
            InitBrowser(browserName);

            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)
        {
            switch(browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;

                case "Edge":
                    driver.Value = new EdgeDriver();
                    break;
            }
        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }

        [TearDown]
        public void AfterTest()
        {
            var status=TestContext.CurrentContext.Result.Outcome.Status;

            if(status == TestStatus.Failed)
            {

            } else if (status==TestStatus.Passed)
            {

            }

            driver.Value.Quit();
        }
    }
}
