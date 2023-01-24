using OpenQA.Selenium;


namespace AmazonAutomation
{
    public class SearchBar
    {
        public IWebDriver driver;

        public string Text
        {
            set
            {
                this.driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(value);
            }
        }

        public SearchBar(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Click()
        {
            // find button by xpath and click
            driver.FindElement(By.XPath("//input[@id=\"nav-search-submit-button\"]")).Click();
        }
    }
}
