using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    // Requirement 5: Define the test class with TestFixture attribute
    [TestFixture]
    public class SampleAppTests
    {
        private IWebDriver _driver;
        private SampleAppPage _sampleAppPage;

        // Requirement 6: Group common setup steps
        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            // Navigate directly to the Sample App section
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/sampleapp");

            // Initialize the page object
            _sampleAppPage = new SampleAppPage(_driver);
        }

        // TC002_2: Verification of a successful login
        [TestCase("TestUser", "pwd", TestName = "TC002_2_SampleApp_SuccessfulLogin")]
        public void VerifySuccessfulLogin(string user, string pass)
        {
            _sampleAppPage.EnterCredentials(user, pass);
            _sampleAppPage.ClickLogin();

            string status = _sampleAppPage.GetLoginStatusText();
            // Requirement 7: Verify result matches expected outcome: "User welcome message appears"
            Assert.That(status, Does.Contain($"Welcome, {user}!"), "The welcome message was not displayed correctly.");
        }

        // TC002_3: Verification of an unsuccessful login
        [TestCase("TestUser", "wrong_password", TestName = "TC002_3_SampleApp_UnsuccessfulLogin")]
        public void VerifyUnsuccessfulLogin(string user, string pass)
        {
            _sampleAppPage.EnterCredentials(user, pass);
            _sampleAppPage.ClickLogin();

            string status = _sampleAppPage.GetLoginStatusText();
            // Requirement 7: Verify result matches expected outcome: "Invalid Username/password message appears"
            Assert.That(status, Is.EqualTo("Invalid username/password"), "The error message for unsuccessful login was not displayed.");
        }

        // Requirement 6: Cleanup resources after test execution
        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit(); // Close browser
                _driver.Dispose(); // Release system resources
            }
        }
    }
}