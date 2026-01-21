using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSE2522_Assignment02.Pages
{
    public class ClientSideDelayPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ClientSideDelayPage(IWebDriver driver)
        {
            _driver = driver;
            // Setting a 20-second timeout to handle the client-side delay
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        // Web Elements
        private IWebElement TriggerButton => _driver.FindElement(By.Id("ajaxButton"));
        private IWebElement SuccessBanner => _driver.FindElement(By.CssSelector(".bg-success"));

        // Actions
        public void ClickTriggerButton()
        {
            TriggerButton.Click();
        }

        public string GetSuccessBannerText()
        {
            // Wait until the loading indicator disappears and the banner is visible
            return _wait.Until(drv => SuccessBanner).Text;
        }
    }
}