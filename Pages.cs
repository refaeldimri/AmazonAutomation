using OpenQA.Selenium;


namespace AmazonAutomation
{
    public class Pages
    {
        private IWebDriver driver;
        public Home home;
        public SearchBar searchBar;
        public Pages(IWebDriver driver)
        {
            this.driver = driver;
        }
        public Home Home
        {
            get
            {
                if (this.home == null)
                {
                    home = new Home(driver);
                }
                return this.home;
            }
        }
        public SearchBar SearchBar
        {
            get
            {
                if (this.searchBar == null)
                {
                    searchBar = new SearchBar(driver);
                }
                return this.searchBar;
            }
        }
    }
}
