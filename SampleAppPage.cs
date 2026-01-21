using OpenQA.Selenium;

namespace CSE2522_Assignment02.Pages
{
    public class SampleAppPage
    {
        private readonly IWebDriver _driver;

        public SampleAppPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Web Elements for Sample App as per the UI Testing Playground
        private IWebElement UserNameField => _driver.FindElement(By.Name("UserName"));
        private IWebElement PasswordField => _driver.FindElement(By.Name("Password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login"));
        private IWebElement LoginStatus => _driver.FindElement(By.Id("loginstatus"));

        // Actions
        public void EnterCredentials(string username, string password)
        {
            UserNameField.Clear();
            UserNameField.SendKeys(username);
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }

        public string GetLoginStatusText()
        {
            return LoginStatus.Text;
        }
    }
}