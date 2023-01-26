using OpenQA.Selenium;


namespace AmazonAutomation
{
    public class Results
    {
        IWebDriver driver;
        List<Item> itemsList = new List<Item>();

        public Results(IWebDriver driver) {
            this.driver = driver;
        }

        public List<Item> getResultsBy(Dictionary<string, string> filterDictionary)
        {
            string xPath = "//div[@class='a-section a-spacing-small a-spacing-top-small'";
            
            foreach (var filter in filterDictionary)
            {
                switch (filter.Key) {
                    case "Price_Lower_Then":
                        xPath += 
                            string.Format(" and concat(concat(descendant::span[@class='a-price-whole']," +
                            " descendant::span[class='a-price-decimal']), descendant::span[@class='a-price-fraction']) < {0}",
                            filter.Value);
                        break;
                    case "Price_Higher_OR_Equal_Then":
                        xPath += 
                            string.Format(" and concat(concat(descendant::span[@class='a-price-whole']," +
                            " descendant::span[class='a-price-decimal']), descendant::span[@class='a-price-fraction']) > {0}",
                            filter.Value);
                        break;
                    case "Free_Shipping":
                        if (filter.Value == "true") 
                            xPath += " and descendant::span[contains(text(), 'FREE')]]";
                        break;
                }
            }
            
            IList<IWebElement> elementsFromAmazon = driver.FindElements(By.XPath(xPath));

            foreach (IWebElement element in elementsFromAmazon)
            {
                string title = element.FindElement(By.XPath(".//span[@class='a-size-medium a-color-base a-text-normal']")).Text;

                string price = "$" + element.FindElement(By.XPath(".//span[@class='a-price-whole']")).Text + "." +
                               element.FindElement(By.XPath("//span[@class='a-price-fraction']")).Text;
                var link = 
                    element.FindElement(By.XPath("//a[@class='a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']")).GetAttribute("href");
                this.itemsList.Add(new Item(title, price, link));
            }
            return itemsList;  
        } 
    }

    /*
     

    "//div[@class='a-section a-spacing-small a-spacing-top-small'"
    " and concat(concat(descendant::span[@class='a-price-whole'], descendant::span[class='a-price-decimal']), descendant::span[@class='a-price-fraction']) > 10"
    " and concat(concat(descendant::span[@class='a-price-whole'], descendant::span[class='a-price-decimal']), descendant::span[@class='a-price-fraction'])<100"
    " and descendant::span[contains(text(), 'FREE')]]"





    
    
    
    //div[@class="a-section a-spacing-small a-spacing-top-small" and concat(concat(descendant::span[@class='a-price-whole'], descendant::span[class="a-price-decimal"]), descendant::span[@class='a-price-fraction']) > 50 and concat(concat(descendant::span[@class='a-price-whole'], descendant::span[class="a-price-decimal"]), descendant::span[@class='a-price-fraction'])<100 and descendant::span[contains(text(), 'FREE')]]
    
    
    
    
    
    //div[@class='a-section a-spacing-small a-spacing-top-small' and concat(concat(descendant::span[@class='a-price-whole'], descendant::span[class='a-price-decimal']), descendant::span[@class='a-price-fraction']) > 100 and concat(concat(descendant::span[@class='a-price-whole'], descendant::span[class='a-price-decimal']), descendant::span[@class='a-price-fraction'])<10 and descendant::span[contains(text(), 'FREE')]]





     
     
     
     */
}
