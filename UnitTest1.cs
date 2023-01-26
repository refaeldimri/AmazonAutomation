

using OpenQA.Selenium;

namespace AmazonAutomation
{
    public class Tests
    {
        BrowserFactory browserFactory;
        Amazon amazon;
        Dictionary<string, string> filterDictionary = new Dictionary<string, string>();
        List<IWebElement> elementsList;
        List<Item> itemsList;

        public void printResults(List<Item> listItems)
        {
            string strToPrint = listItems.Count > 1 ? "there are " + listItems.Count + " items:\n": 
                                                        "there is " + listItems.Count + " item:\n";
            Console.WriteLine("there are " + listItems.Count + " items:\n");
            foreach (Item item in itemsList)
            {
                Console.WriteLine("Product name: " + item.Title);
                Console.WriteLine("Product price: " + item.Price);
                Console.WriteLine("Product link: " + item.Link + "\n\n");
            }
        }

        [SetUp]
        public void Setup()
        {
            browserFactory = new BrowserFactory();
            filterDictionary.Add("Price_Lower_Then", "100");
            filterDictionary.Add("Price_Higher_OR_Equal_Then", "10");
            filterDictionary.Add("Free_Shipping", "true");
            elementsList = new List<IWebElement>();
        }

        [Test]
        public void TestChrome()
        {
            browserFactory.InitBrowser("Chrome");
            amazon = new Amazon(browserFactory.Drivers["CHROME"]);
            amazon.Pages.Home.SearchBar.Text = "mouse";
            amazon.Pages.Home.SearchBar.Click();
            itemsList = amazon.Pages.Results.getResultsBy(filterDictionary);
            printResults(itemsList);
        }
        [Test]
        public void TestExploror()
        {
            browserFactory.InitBrowser("IE");
            amazon = new Amazon(browserFactory.Drivers["IE"]);
            amazon.Pages.Home.SearchBar.Text = "mouse";
            amazon.Pages.Home.SearchBar.Click();
            itemsList = amazon.Pages.Results.getResultsBy(filterDictionary);
            printResults(itemsList);
        }
        [Test]
        public void TestFireFox()
        {
            browserFactory.InitBrowser("FIREFOX");
            amazon = new Amazon(browserFactory.Drivers["FIREFOX"]);
            amazon.Pages.Home.SearchBar.Text = "mouse";
            amazon.Pages.Home.SearchBar.Click();
            itemsList = amazon.Pages.Results.getResultsBy(filterDictionary);
            printResults(itemsList);
        }
    }
}