using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture] // Requirement 5: Define the test class
    public class ClientSideDelayTests
    {
        private IWebDriver _driver;
        private ClientSideDelayPage _clientSideDelayPage;

        [SetUp] // Requirement 6: Group common setup steps
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            // Navigate to the target application URL
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/clientdelay");

            // Initialize the page object
            _clientSideDelayPage = new ClientSideDelayPage(_driver);
        }

        // TC003_1: Verification of the client side delay page
        [Test]
        [TestCase(TestName = "TC003_1_ClientSideDelay_Verification")]
        public void VerifyClientSideDelayBanner()
        {
            // Act: Click the button to trigger client-side logic
            _clientSideDelayPage.ClickTriggerButton();

            // Assert: Wait for banner and verify the text
            string expectedMessage = "Data calculated on the client side.";
            string actualMessage = _clientSideDelayPage.GetSuccessBannerText();

            Assert.That(actualMessage, Is.EqualTo(expectedMessage),
                "The success banner message did not match the expected outcome.");
        }

        [TearDown] // Requirement 6: Resource cleanup
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit(); // Requirement 6: Close browser
                _driver.Dispose(); // Requirement 6: Release resources
            }
        }
    }
}