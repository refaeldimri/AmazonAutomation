using OpenQA.Selenium;
using AmazonAutomation;

namespace AmazonAutomation
{
    public class Tests
    {
        BrowserFactory browserFactory;
        Amazon amazonInfraAuto;
        [SetUp]
        public void Setup()
        {
            browserFactory = new BrowserFactory();
        }

        [Test]
        public void TestChrome()
        {
            browserFactory.InitBrowser("Chrome");
            amazonInfraAuto = new Amazon(browserFactory.Drivers["CHROME"]);
            amazonInfraAuto.Pages.Home.SearchBar.Text = "mouse";
            amazonInfraAuto.Pages.Home.SearchBar.Click();
        }
        [Test]
        public void TestExploror()
        {
            browserFactory.InitBrowser("IE");
            amazonInfraAuto = new Amazon(browserFactory.Drivers["IE"]);
            amazonInfraAuto.Pages.Home.SearchBar.Text = "mouse";
            amazonInfraAuto.Pages.Home.SearchBar.Click();
        }
        [Test]
        public void TestFireFox()
        {
            browserFactory.InitBrowser("FIREFOX");
            amazonInfraAuto = new Amazon(browserFactory.Drivers["FIREFOX"]);
            amazonInfraAuto.Pages.Home.SearchBar.Text = "mouse";
            amazonInfraAuto.Pages.Home.SearchBar.Click();
        }
    }
}