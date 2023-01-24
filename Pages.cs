using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAutomation
{
    public class Pages
    {
        IWebDriver driver;
        public HomePage homePage;
        public SearchBar searchBar;
        public Pages(IWebDriver driver)
        {
            this.driver = driver;
            this.homePage = new HomePage(driver);
            this.searchBar = new SearchBar(driver);
        }
    }
}
