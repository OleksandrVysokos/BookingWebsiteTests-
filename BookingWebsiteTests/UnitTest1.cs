using BookingWebsiteTests.PageObjects;
using BookingWebsiteTests.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BookingWebsiteTests
{
    public class Tests
    {
        private IWebDriver _webDriver;
        private readonly By _assertDecember1 = By.XPath("//button[text()='Thursday, December 1, 2022']");
        private readonly By _assertDecember31 = By.XPath("//button[text()='Saturday, December 31, 2022']");

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("https://www.booking.com");
            _webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var mainMenu = new MainPagePageObjects(_webDriver);

            var searchPage = new SearchPagePageObjects(_webDriver);

            mainMenu.SelectEnglishUsVersion()
                .SelectCurrencyUSD()
                .EnterDestinationNewYork()
                .SelectDate()
                .ClickSearch();
            string december1 = _webDriver.FindElement(_assertDecember1).Text;
            string december31 = _webDriver.FindElement(_assertDecember31).Text;
            Assert.AreEqual("1\r\nThursday, December 1, 2022", december1);
            Assert.AreEqual("31\r\nSaturday, December 31, 2022", december31);
            Assert.AreEqual("New York", searchPage.GetTextDestinationPropertyName().ToString());
            Assert.AreEqual("New York", searchPage.GetTextCityNameFromSearchRezult().ToString());
            Assert.AreEqual(true, searchPage.isCityNewYorkInAllCardsSearchRezult());

        }

        [Test]
        public void Test2()
        {
            var mainMenu = new MainPagePageObjects(_webDriver);

            mainMenu.SelectEnglishUsVersion()
                .SelectCurrencyUSD()
                .AttractionsPage()
                .SelectCityInAttractionsLondon()
                .MuseumsFilterSelect()
                .SelectMuseumFromList();
        }
    }
}