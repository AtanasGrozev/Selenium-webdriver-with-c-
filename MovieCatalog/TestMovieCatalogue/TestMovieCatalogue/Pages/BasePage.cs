using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMovieCatalogue.Pages
{
    public class BasePage 
        
    {
       
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }
        public string BaseUrl => "http://moviecatalog-env.eba-ubyppecf.eu-north-1.elasticbeanstalk.com/";
        public void OpenPageBaseUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);

        }

        public IWebElement LoginLinkButton => driver.FindElement(By.XPath("//a[@class='nav-link js-scroll-trigger active']"));
        public IWebElement LoginHereButton => driver.FindElement(By.XPath("//a[@id='loginBtn']"));
        public IWebElement AddMovieLink => driver.FindElement(By.XPath("//a[text()='Add Movie']"));
        public IWebElement AllMovieLink => driver.FindElement(By.XPath("//a[text()='All Movies']"));
        public IWebElement WatchedMovieLink => driver.FindElement(By.XPath("//a[text()='Watched Movies']"));
        public IWebElement UnwatchedMovieLink => driver.FindElement(By.XPath("//a[text()='Unwatched Movies']")); 
        public IWebElement LogoutButton => driver.FindElement(By.XPath("//button[text()='Logout']"));

    }
}
