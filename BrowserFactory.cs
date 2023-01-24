using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;


namespace AmazonAutomation
{
    internal class BrowserFactory
    {
        public IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        public void InitBrowser(string browserName)
        {
            switch (browserName.ToUpper())
            {
                case "FIREFOX":
                    {
                        if (!Drivers.ContainsKey("FIREFOX"))
                            Drivers.Add("FIREFOX", new FirefoxDriver());
                    }
                    break;

                case "IE":
                    {
                        if (!Drivers.ContainsKey("IE"))
                            Drivers.Add("IE", new InternetExplorerDriver());
                    }
                    break;

                case "CHROME":
                    {
                        if (!Drivers.ContainsKey("CHROME"))
                            Drivers.Add("CHROME", new ChromeDriver());
                    }
                    break;
            }
        }

        public void LoadApplication(string url, string driverName)
        {
            Drivers[driverName].Url = url;
        }

        public void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}
