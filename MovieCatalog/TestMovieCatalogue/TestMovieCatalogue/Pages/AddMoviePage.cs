using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMovieCatalogue.Pages
{
    public class AddMoviePage : BasePage
    {
        public AddMoviePage(IWebDriver driver) : base(driver)
        {
            
        }
        public string UrlAddMovie => BaseUrl + "Catalog/Add#add";
        public void OpenPageAddMovie()
        {
            driver.Navigate().GoToUrl(UrlAddMovie); 
        }
        public IWebElement TitleField => driver.FindElement(By.XPath("//input[@name='Title']"));
        public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@name='Description']"));
        public IWebElement MarkAsWatchedCheckBox => driver.FindElement(By.XPath("//input[@class='form-check-input']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));
        public IWebElement ErrorTitleField => driver.FindElement(By.XPath("//div[@class='toast-message']"));//The Title field is required.
        public IWebElement ErrorDescriptionField => driver.FindElement(By.XPath("//div[@class='toast-message']")); //The Description field is required. 

        public void AddMovieMethod(string title, string description)
        {
            TitleField.Clear();
            TitleField.SendKeys(title);
            DescriptionField.Clear();
            DescriptionField.SendKeys(description);

        }




    }
}
