using OpenQA.Selenium;


namespace AmazonAutomation
{
    public class Pages
    {
        private IWebDriver driver;
        public Home home;
        public Results result;
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
        public Results Results
        {
            get
            {
                if (this.result == null)
                {
                    result = new Results(driver);
                }
                return this.result;
            }
        }
    }
}
