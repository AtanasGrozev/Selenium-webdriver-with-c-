using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMovieCatalogue.Pages
{
    public class WatchedMoviePAge : BasePage
    {

        public WatchedMoviePAge(IWebDriver driver) : base(driver)
        {
            
        }

        public string UrlWatchedMovie => BaseUrl + "Catalog/Watched#watched";

        public void OpePageWatchedMovie()
        {
            driver.Navigate().GoToUrl(UrlWatchedMovie);
        }


        public ReadOnlyCollection<IWebElement> AllMovies => driver.FindElements(By.XPath("//div[@class='col-lg-4']"));
        public IWebElement LastMovie => AllMovies.Last();

        public ReadOnlyCollection<IWebElement> ALLlastMovieTitle => LastMovie.FindElements(By.XPath("//div[@class='col-lg-4']//h2"));
        public IWebElement LastMovieTitle => ALLlastMovieTitle.Last();

        public IWebElement EditButton => LastMovie.FindElement(By.XPath(".//a[@class='btn btn-outline-success']"));
        public IWebElement DeleteButton => LastMovie.FindElement(By.XPath(".//a[@class='btn btn-danger']"));
        public IWebElement MarkAsWatchedButton => LastMovie.FindElement(By.XPath(".//a[@class='btn btn-info]"));

    }
}
