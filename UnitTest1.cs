

using OpenQA.Selenium;

namespace AmazonAutomation
{
    public class Tests
    {
        BrowserFactory browserFactory;
        Amazon amazon;
        Dictionary<string, string> filterDictionary = new Dictionary<string, string>();
        List<IWebElement> elementsList;
        [SetUp]
        public void Setup()
        {
            browserFactory = new BrowserFactory();
            filterDictionary.Add("Price_Lower_Then", "100");
            filterDictionary.Add("Price_Higher_OR_Equal_Then", "1");
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
            elementsList = amazon.Pages.Results.getResultsBy(filterDictionary);

            foreach (IWebElement element in elementsList)
            {
                Console.WriteLine(element.Text + "\n\n\n\n");
            }
        }
        [Test]
        public void TestExploror()
        {
            browserFactory.InitBrowser("IE");
            amazon = new Amazon(browserFactory.Drivers["IE"]);
            amazon.Pages.Home.SearchBar.Text = "mouse";
            amazon.Pages.Home.SearchBar.Click();
        }
        [Test]
        public void TestFireFox()
        {
            browserFactory.InitBrowser("FIREFOX");
            amazon = new Amazon(browserFactory.Drivers["FIREFOX"]);
            amazon.Pages.Home.SearchBar.Text = "mouse";
            amazon.Pages.Home.SearchBar.Click();
        }
    }
}