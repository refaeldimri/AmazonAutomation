using OpenQA.Selenium;
using AmazonAutomation;

namespace AmazonAutomation
{
    public class Tests
    {
        BrowserFactory browserFactory;
        AmazonInfraAuto amazonInfraAuto;
        [SetUp]
        public void Setup()
        {
            browserFactory = new BrowserFactory();
        }

        [Test]
        public void TestChrome()
        {
            browserFactory.InitBrowser("Chrome");
            amazonInfraAuto = new AmazonInfraAuto(browserFactory.Drivers["CHROME"]);
            amazonInfraAuto.pages.homePage.searchBar.Text = "mouse";
            amazonInfraAuto.pages.homePage.searchBar.Click();
        }
        [Test]
        public void TestExploror()
        {
            browserFactory.InitBrowser("IE");
            amazonInfraAuto = new AmazonInfraAuto(browserFactory.Drivers["IE"]);
            amazonInfraAuto.pages.homePage.searchBar.Text = "mouse";
            amazonInfraAuto.pages.homePage.searchBar.Click();
        }
        [Test]
        public void TestFireFox()
        {
            browserFactory.InitBrowser("FIREFOX");
            amazonInfraAuto = new AmazonInfraAuto(browserFactory.Drivers["FIREFOX"]);
            amazonInfraAuto.pages.homePage.searchBar.Text = "mouse";
            amazonInfraAuto.pages.homePage.searchBar.Click();
        }
    }
}