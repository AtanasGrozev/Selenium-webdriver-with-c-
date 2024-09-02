using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIdeaCenter.Pages
{
    public class EditPage:BasePage
    {

        public EditPage(IWebDriver driver) : base(driver)
        {
            
        }
        public string Url = BaseUrl + "/Ideas/Myideas";

        public void Openpage()
        {
            driver.Navigate().GoToUrl(Url); 

        }

        public IWebElement EditedTitle => driver.FindElement(By.XPath("//input[@id='form3Example1c']"));
         public IWebElement EditedDescribtion => driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));
        public IWebElement EditButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

        public void EditIdea(string title, string description)
        {
            EditedTitle.Clear();
            EditedTitle.SendKeys(title);
            EditedDescribtion.Clear();
            EditedDescribtion.SendKeys(description);
            EditButton.Click();
        }


    }
}
