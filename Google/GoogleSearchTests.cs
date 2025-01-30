using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages;

namespace SeleniumTests
{
    [TestFixture]
    public class GoogleSearchTests
    {
        private IWebDriver _driver;
        private GooglePage _googlePage;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--user-agent=Mozilla/5.0 (iPhone; CPU iPhone OS 14_0 like Mac OS X) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Mobile Safari/537.36");
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _googlePage = new GooglePage(_driver);
        }

        [Test]
        public void SearchForSeleniumTutorial()
        {
            _googlePage.NavigateTo();

            Assert.That(_googlePage.IsSearchBoxDisplayed(), "Search field is not available");

            _googlePage.EnterSearchText("Selenium C# tutorial");

            _googlePage.PressEnter();

            Assert.That(_googlePage.AreSearchResultsDisplayed(), "Results are not displayed");

            var firstResultText = _googlePage.GetFirstResultText();
            Assert.That(firstResultText.Contains("Selenium"), "First result does not contain 'Selenium'");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
