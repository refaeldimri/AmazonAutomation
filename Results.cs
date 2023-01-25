using OpenQA.Selenium;
using System.Security.Claims;


namespace AmazonAutomation
{
    public class Results
    {
        IWebDriver driver;

        public Results(IWebDriver driver) {
            this.driver = driver;
        }

        public IList<IWebElement> getResultsBy(Dictionary<string, string> filterDictionary)
        {
            string xPath = "//div[@class='a-section a-spacing-small a-spacing-top-small'";
            
            foreach (var filter in filterDictionary)
            {
                switch (filter.Key) {
                    case "Price_Lower_Then":
                        xPath += string.Format(" and descendant::span[@class = 'a-price-whole' and text() <= '{0}'", filter.Value);
                        break;
                    case "Price_Higher_OR_Equal_Then":
                        xPath += string.Format(" and text()>='{0}']", filter.Value);
                        break;
                    case "Free_Shipping":
                        if (filter.Value == "true") xPath += " and descendant::span[contains(text(), 'FREE')]]";
                        break;
                }
            }
            IList<IWebElement> elements = driver.FindElements(By.XPath(xPath));
            return elements;
            
        }
    }
}
