using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;
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
             //_driver = new ChromeDriver(DriverDirectory);
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


            _driver.Navigate().GoToUrl("C:\\Users\\ramus\\MusicFrontEnd\\MusicFrontEnd\\index.html"); // åbner siden
            Assert.AreEqual("Music Record REST", _driver.Title); // tester om titlen er korrekt

            IWebElement buttonElement = _driver.FindElement(By.Id("button")); // finder knappen
            buttonElement.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)); // decorator pattern?
            IWebElement recordsList = wait.Until(d => d.FindElement(By.Id("list")));
            Assert.IsTrue(recordsList.Text.Contains("Pink Floyd"));

            ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.TagName("li"));
            Assert.AreEqual(10, listElements.Count);

        }
    }
}