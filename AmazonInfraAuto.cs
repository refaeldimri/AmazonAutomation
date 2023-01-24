using OpenQA.Selenium;

namespace AmazonAutomation
{
    public class AmazonInfraAuto
    {
        IWebDriver driver;
        public Pages pages;

        public AmazonInfraAuto(IWebDriver driver)
        {
            this.driver = driver;
            this.pages = new Pages(driver);
        }
    }
}
