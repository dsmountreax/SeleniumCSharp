using NUnit.Framework;

namespace NunitSeleniumLearning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup method execution");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("This is test 1");
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("This is test 2");
        }

        [TearDown] // Codigo que se ejecuta despues de la prueba.
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("Tear down method");
        }
    }
}