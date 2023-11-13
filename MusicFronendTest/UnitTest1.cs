using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MusicFrontendTest
{

    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\webdrivers"; // mappe med driver til browser her kun firefox downloades online. Vigtigt at den matcher driver version og browser version
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            // _driver = new ChromeDriver(DriverDirectory);
            _driver = new FirefoxDriver(DriverDirectory);   // firefox driver
            // _driver = new EdgeDriver(DriverDirectory); 
        }

        [ClassCleanup]
        public static void TearDown() // lukker browseren
        {
            _driver.Dispose(); // lukker browseren
        }

        [TestMethod]
        public void TestMethod1()
        {


            _driver.Navigate().GoToUrl("file:///C:/Users/eugdk/Desktop/MusicFrontEnd/index.html"); // åbner siden
            Assert.AreEqual("Music Record REST", _driver.Title); // tester om titlen er korrekt

            IWebElement buttonElement = _driver.FindElement(By.Id("button")); // finder knappen
            buttonElement.Click();


           
            

        }
    }
}