using OpenQA.Selenium;
using System.Collections.Generic;

namespace AmazonAutomation
{
    public class Results
    {
        IWebDriver driver;
        string xPath;
        public Results(IWebDriver driver) {
            this.driver = driver;
        }

        public List<Item> getResultsBy(Dictionary<string, string> filterDictionary)
        {
            this.xPath = "//span[@class=\"a-price-whole\" ";
            foreach (var filter in filterDictionary)
            {
                switch (filterDictionary[filter.Key]) {
                    case "price_lower_then":
                        xPath += " and text() > " + filter.Value;  
                        break;
                    case "free shipping":
                        if (filter.Value == "True") xPath += 
                        break;
                }
            }

            IList<IWebElement> elements = driver.FindElements(By.XPath(xPath));
            //// to continues...
            return elements;
        }

    }
}
