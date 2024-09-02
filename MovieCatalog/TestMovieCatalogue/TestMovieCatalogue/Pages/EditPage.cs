using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMovieCatalogue.Pages
{
    public class EditPage : BasePage
    {
        public EditPage(IWebDriver driver): base(driver)
        {
            
        }
        public IWebElement TitleField => driver.FindElement(By.XPath("//input[@name='Title']"));
        public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@name='Description']"));
        public IWebElement MarkAsWatchedCheckBox => driver.FindElement(By.XPath("//input[@class='form-check-input']"));
        public IWebElement EditButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));
       
       
        public void EditMovieMethod(string title, string description)
        {
            TitleField.Clear();
            TitleField.SendKeys(title);
            DescriptionField.Clear();
            DescriptionField.SendKeys(description);

        }

    }
}
