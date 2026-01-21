using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace CSE2522_Assignment02.Pages
{
    public class AlertPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public AlertPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Locators
        private IWebElement AlertButton => _driver.FindElement(By.Id("alert"));
        private IWebElement ConfirmButton => _driver.FindElement(By.Id("confirm"));
        private IWebElement PromptButton => _driver.FindElement(By.Id("prompt"));

        // User Action Methods
        public void ClickAlertButton() => AlertButton.Click();
        public void ClickConfirmButton() => ConfirmButton.Click();
        public void ClickPromptButton() => PromptButton.Click();

        // Alert Interaction Methods
        public string GetAlertText()
        {
            IAlert alert = _wait.Until(ExpectedConditions.AlertIsPresent())!;
            return alert.Text!; // Null-forgiving operator removes CS8603 warning
        }

        public void AcceptAlert()
        {
            IAlert alert = _wait.Until(ExpectedConditions.AlertIsPresent())!;
            alert.Accept();
        }

        public void DismissAlert()
        {
            IAlert alert = _wait.Until(ExpectedConditions.AlertIsPresent())!;
            alert.Dismiss();
        }

        public void SendKeysToPrompt(string text)
        {
            IAlert alert = _wait.Until(ExpectedConditions.AlertIsPresent())!;
            alert.SendKeys(text);
        }
    }
}
