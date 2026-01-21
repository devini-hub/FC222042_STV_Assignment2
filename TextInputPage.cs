using OpenQA.Selenium;

namespace CSE2522_Assignment02
{
    public class TextInputPage
    {
        private readonly IWebDriver _driver;

        public TextInputPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Using finders that are standard for Selenium POM
        private IWebElement MyTextInput => _driver.FindElement(By.Id("newBrowserName"));
        private IWebElement UpdateButton => _driver.FindElement(By.Id("updatingButton"));

        public void EnterNewButtonName(string text)
        {
            MyTextInput.Clear();
            MyTextInput.SendKeys(text);
        }

        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }

        public string GetButtonText()
        {
            return UpdateButton.Text;
        }
    }
}