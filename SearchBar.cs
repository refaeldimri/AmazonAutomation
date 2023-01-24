using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AmazonAutomation
{
    public class SearchBar
    {
        public IWebDriver driver;
        private string text = "Insert product";
        Results results;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public SearchBar(IWebDriver driver)
        {
            this.driver = driver;
            this.results = new Results(driver);
        }

        public void Click()
        {
            // Navigate to Url
            driver.Navigate().GoToUrl("https://www.amazon.com");

            // maximaize to window
            driver.Manage().Window.Maximize();

            // find elements (search bar) and put him <<text>>
            driver.FindElement(By.XPath("//input[@id=\"twotabsearchtextbox\"]")).SendKeys(this.text);

            // find button by xpath and click
            driver.FindElement(By.XPath("//input[@id=\"nav-search-submit-button\"]")).Click();
        }
    }
}
