using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingWebsiteTests.PageObjects
{
    class MainPagePageObjects
    {
        private IWebDriver _webDriver;
        Actions actions;
        private readonly By _selectLanguageButton = By.XPath("//button[@data-modal-id='language-selection']");
        private readonly By _selectEngUS = By.XPath("//a[@data-lang='en-us']");
        private readonly By _selectCurrencyButton = By.XPath("//button[@data-modal-header-async-type='currencyDesktop']");
        private readonly By _selectUsd = By.XPath("//a[@data-modal-header-async-url-param='changed_currency=1&selected_currency=USD&top_currency=1']");
        private readonly By _searchCityField = By.XPath("//input[@type='search']");
        private const string _destinationNewYork = "New York";
        private readonly By _searchButton = By.CssSelector(".sb-searchbox__button");
        private readonly By _dateField = By.XPath("//span[@class='sb-date-field__icon sb-date-field__icon-btn bk-svg-wrapper calendar-restructure-sb']");
        private readonly By _nextMonthClick = By.XPath("//div[@data-bui-ref='calendar-next']");
        private readonly By _findDecember1 = By.XPath("//td[@data-date='2022-12-01']");
        private readonly By _findDecember31 = By.XPath("//td[@data-date='2022-12-31']");
        private readonly By _attractionsButton = By.XPath("//a[@data-decider-header='attractions']");
        private readonly By _selectLondonAttractions = By.XPath("//div[text()='London']");
        private readonly By _filterMuseums = By.XPath("//span[text()='Museums']");
        private readonly By _lowestPriceFilter = By.XPath("//li[text()='Lowest price']");
        private readonly By _selectMuseum = By.XPath("//a[@title='The Painted Hall Admission']");
        private readonly By _datePick = By.XPath("//div[@data-testid='datepicker']");
        public MainPagePageObjects(IWebDriver webdriver)
        {
            _webDriver = webdriver;
            actions = new Actions(webdriver);
        }
        public MainPagePageObjects SelectEnglishUsVersion()
        {
            WaitUntil.WaitElement(_webDriver, _selectLanguageButton);
            _webDriver.FindElement(_selectLanguageButton).Click();
            WaitUntil.WaitElement(_webDriver, _selectEngUS);
            _webDriver.FindElement(_selectEngUS).Click();
            return new MainPagePageObjects(_webDriver);
        }
        public MainPagePageObjects SelectCurrencyUSD()
        {
            WaitUntil.WaitElement(_webDriver, _selectCurrencyButton);
            _webDriver.FindElement(_selectCurrencyButton).Click();
            WaitUntil.WaitElement(_webDriver, _selectUsd);
            _webDriver.FindElement(_selectUsd).Click();
            return new MainPagePageObjects(_webDriver);
        }
        public MainPagePageObjects EnterDestinationNewYork()
        {
            WaitUntil.WaitElement(_webDriver, _searchCityField);
            _webDriver.FindElement(_searchCityField).Click();
            WaitUntil.WaitElement(_webDriver, _searchCityField);
            _webDriver.FindElement(_searchCityField).SendKeys(_destinationNewYork);
            return new MainPagePageObjects(_webDriver);
        }
        public MainPagePageObjects SelectDate()
        {
            WaitUntil.WaitElement(_webDriver, _dateField);
            _webDriver.FindElement(_dateField).Click();
            WaitUntil.WaitElement(_webDriver, _nextMonthClick);
            _webDriver.FindElement(_nextMonthClick).Click();
            _webDriver.FindElement(_nextMonthClick).Click();
            WaitUntil.WaitElement(_webDriver, _findDecember1);
            _webDriver.FindElement(_findDecember1).Click();
            _webDriver.FindElement(_findDecember31).Click();
            return new MainPagePageObjects(_webDriver);
        }
        public MainPagePageObjects ClickSearch()
        {
            WaitUntil.WaitElement(_webDriver, _searchButton);
            _webDriver.FindElement(_searchButton).Click();
            return new MainPagePageObjects(_webDriver);
        }
        public MainPagePageObjects AttractionsPage()
        {
            WaitUntil.WaitElement(_webDriver, _attractionsButton);
            _webDriver.FindElement(_attractionsButton).Click();
            return new MainPagePageObjects(_webDriver);
        }
        public MainPagePageObjects SelectCityInAttractionsLondon()
        {
            WaitUntil.WaitElement(_webDriver, _selectLondonAttractions);
            _webDriver.FindElement(_selectLondonAttractions).Click();
            return new MainPagePageObjects(_webDriver);
        }
        public MainPagePageObjects MuseumsFilterSelect()
        {
            WaitUntil.WaitElement(_webDriver, _filterMuseums);
            _webDriver.FindElement(_filterMuseums).Click();
            WaitUntil.WaitElement(_webDriver, _lowestPriceFilter);
            _webDriver.FindElement(_lowestPriceFilter).Click();
            return new MainPagePageObjects(_webDriver);
        }
        public MainPagePageObjects SelectMuseumFromList()
        {
            WaitUntil.WaitElement(_webDriver, _selectMuseum);
            _webDriver.FindElement(_selectMuseum).Click();
            var place = _webDriver.FindElement(By.XPath("//*[text()='The Painted Hall Admission']"));
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", place);
             Assert.AreEqual("The Painted Hall Admission", place.Text);
            return new MainPagePageObjects(_webDriver);
        }
    }
}
