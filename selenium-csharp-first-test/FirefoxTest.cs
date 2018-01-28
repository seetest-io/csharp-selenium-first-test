using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace selenium_csharp_first_test
{
    [TestFixture]
    public class FirefoxTest
    {

        private string accessKey = "";
        private string testName = "Selenium On Firefox";

        private string CLOUDURL = "https://cloud.seetest.io/wd/hub";
        protected RemoteWebDriver driver = null;

        DesiredCapabilities dc = new DesiredCapabilities();

        [SetUp()]
        public void SetupTest()
        {
            dc.SetCapability("testName", testName);
            dc.SetCapability("accessKey", accessKey);
            dc.SetCapability(CapabilityType.BrowserName, "firefox");
            driver = new RemoteWebDriver(new Uri(CLOUDURL), dc);
        }

        [Test()]
        public void TestFirefoxWithSelenium()
        {
            driver.Navigate().GoToUrl("http://seetest.io");
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.XPath("//*[text()='Manual']")));
            IWebElement manualNavLink = driver.FindElement(By.XPath("//*[text()='Manual']"));
            manualNavLink.Click();

            IWebElement automationNavLink = driver.FindElement(By.XPath("//*[text()='Automation']"));
            automationNavLink.Click();

            IWebElement webinarFooterLink = driver.FindElement(By.XPath("//*[text()='Webinars']"));

            webinarFooterLink.Click();

            String webinarH2TitleText = driver.FindElement(By.XPath("//h2[1]")).Text;

            Console.WriteLine("The title of the first h2 is: " + webinarH2TitleText);
        }

        [TearDown()]
        public void TearDown()
        {

            driver.Quit();

        }
    }
}
