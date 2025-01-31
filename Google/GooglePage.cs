using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class GooglePage
    {
        private readonly IWebDriver _driver;

        private readonly By _searchBox = By.Name("q");
        private readonly By _searchResults = By.Id("search");
        private readonly By _firstResult = By.CssSelector("#search .g:first-child");

        public GooglePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://www.google.com");
        }

        public bool IsSearchBoxDisplayed()
        {
            return _driver.FindElement(_searchBox).Displayed;
        }

        public void EnterSearchText(string text)
        {
            var searchBox = _driver.FindElement(_searchBox);
            searchBox.Clear();
            searchBox.SendKeys(text);
        }

        public void PressEnter()
        {
            _driver.FindElement(_searchBox).SendKeys(Keys.Enter);
        }

        public bool AreSearchResultsDisplayed()
        {
            return _driver.FindElement(_searchResults).Displayed;
        }

        public string GetFirstResultText()
        {
            return _driver.FindElement(_firstResult).Text;
        }
    }
}
