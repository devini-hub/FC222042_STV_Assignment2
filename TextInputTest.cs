using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSE2522_Assignment02;

namespace CSE2522_Assignment02.Tests
{
    // Requirement 5: Define the test class with the TestFixture attribute
    [TestFixture]
    public class TextInputTests
    {
        private IWebDriver _driver;
        private TextInputPage _textInputPage;

        // Requirement 6: Initialize browser and page objects in the SetUp method
        [SetUp]
        public void SetUp()
        {
            // Requirement 10: Use Selenium WebDriver to interact with the application
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            // Navigate to the specific URL for the Text Input task
            _driver.Navigate().GoToUrl("https://uitestingplayground.com/textinput");

            // Requirement 13 & 20: Initialize the Page Object class
            _textInputPage = new TextInputPage(_driver);
        }

        // Requirement 16 & 17: Explicitly name the test using the TestName attribute
        [TestCase("Assignment Test", TestName = "TC_TextInput_001_VerifyButtonTextChange")]
        public void VerifyButtonNameChange(string inputData)
        {
            // Requirement 10: Perform user actions (Enter input and click)
            _textInputPage.EnterNewButtonName(inputData);
            _textInputPage.ClickUpdateButton();

            // Requirement 11 & 22: Use NUnit assertions to verify the expected result
            string actualButtonText = _textInputPage.GetButtonText();
            Assert.That(actualButtonText, Is.EqualTo(inputData),
                "The button text did not update to match the entered input data.");
        }

        // Requirement 21: Properly clean up resources after test execution
        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit(); // Requirement 21: Close the browser
                _driver.Dispose(); // Requirement 21: Release system resources
            }
        }
    }
}