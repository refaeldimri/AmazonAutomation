using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAutomation
{
    public class HomePage
    {
        IWebDriver driver;
        public SearchBar searchBar;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.searchBar = new SearchBar(driver);

        }
    }
}
