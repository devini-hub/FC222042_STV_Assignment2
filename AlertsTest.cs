using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class AlertTests
    {
        private IWebDriver _driver;
        private AlertPage _alertPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/alerts");
            _alertPage = new AlertPage(_driver);
        }

        [Test]
        [TestCase(TestName = "TC004_2_VerifyAlertText")]
        public void VerifyAlertText()
        {
            _alertPage.ClickAlertButton();

            // This will now wait for the alert properly
            string text = _alertPage.GetAlertText();
            Assert.That(text, Is.EqualTo("Today is a working day or less likely a holiday"));

            _alertPage.AcceptAlert();
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}