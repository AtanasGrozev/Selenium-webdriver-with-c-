using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMovieCatalogue.Pages
{
    public class AllMoviePage : BasePage
    {
        public AllMoviePage(IWebDriver driver): base(driver)
        {
            
        }
        public string UrlAllMovie => BaseUrl + "Catalog/All#all";
        public void OpenPageAllMovie()
        {
              driver.Navigate().GoToUrl(UrlAllMovie); 
        }
        //LastPage
        public ReadOnlyCollection<IWebElement> PageIndexes => driver.FindElements(By.XPath("//a[@class='page-link']"));
        public void NavigateTolastPage()
        {           
           PageIndexes.Last().Click();
        }
        //LastMovie and Title

        public ReadOnlyCollection<IWebElement> AllMovies => driver.FindElements(By.XPath("//div[@class='col-lg-4']"));
        public IWebElement LastMovie => AllMovies.Last();

        public ReadOnlyCollection<IWebElement> ALLlastMovieTitle => LastMovie.FindElements(By.XPath("//div[@class='col-lg-4']//h2"));
        public IWebElement LastMovieTitle => ALLlastMovieTitle.Last();

        public IWebElement EditButton => LastMovie.FindElement(By.XPath(".//a[@class='btn btn-outline-success']")); 
        public IWebElement DeleteButton => LastMovie.FindElement(By.XPath(".//a[@class='btn btn-danger']"));
        public IWebElement MarkAsWatchedButton => LastMovie.FindElement(By.XPath(".//a[@class='btn btn-info']"));
       






    }
}
