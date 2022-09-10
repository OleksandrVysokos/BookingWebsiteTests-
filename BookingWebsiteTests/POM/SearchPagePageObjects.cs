using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingWebsiteTests.POM
{
    class SearchPagePageObjects
    {
        private IWebDriver _webdriver;
        private Actions actions;
        private readonly By _destination_property_name = By.XPath("/html/body/div[2]/div/div[3]/div[1]/div[2]/div[1]/div[1]/div/div/form/div/div[2]/div/div[2]/div[1]/div/div/input");
        private readonly By _search_rezult_title = By.XPath("//*[@id=\"right\"]/div[1]/div/div/div/h1");
        private readonly By _location_in_the_cards = By.XPath("//*[@data-testid=\"address\"]");

        public SearchPagePageObjects(IWebDriver webdriver)
        {
            _webdriver = webdriver;
            actions = new Actions(webdriver);
        }
        public string GetTextDestinationPropertyName()
        {
            Console.WriteLine("Destination/property name: " + _webdriver.FindElement(_destination_property_name).GetAttribute("value"));
            return _webdriver.FindElement(_destination_property_name).GetAttribute("value");

        }


        public string GetTextCityNameFromSearchRezult()
        {
            new WebDriverWait(_webdriver, TimeSpan.FromSeconds(15)).Until(ExpectedConditions.ElementIsVisible(_search_rezult_title));
            Console.WriteLine("Search results title: " + _webdriver.FindElement(_search_rezult_title).Text);
            string[] subs = _webdriver.FindElement(_search_rezult_title).Text.Split(':');
            return subs[0];

        }

        public bool isCityNewYorkInAllCardsSearchRezult()

        {
            bool flag = false;
            IReadOnlyList<IWebElement> cities = _webdriver.FindElements(_location_in_the_cards);

            Console.WriteLine("Location search results in cards :");

            for (int i = 0; i < cities.Count; i++)
            {
                Console.WriteLine($"Card number: {i + 1}. Find: {cities[i].Text}");
                string[] subs = cities[i].Text.Split(',');

                if (subs[1].Trim(' ') == "New York")
                {
                    flag = true;
                    Console.WriteLine("Is this location New York? -> " + flag);
                }
                else
                {
                    flag = false;
                    Console.WriteLine("Is this location New York? -> " + flag);
                    break;
                }

            }

            return flag;

        }

    }
}

