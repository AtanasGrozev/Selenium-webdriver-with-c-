using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMovieCatalogue.Pages
{
    public class DeletePage : BasePage
    {
        public DeletePage(IWebDriver driver): base(driver)
        {            
        }
        public IWebElement DeleteButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));
        public IWebElement DeleteMessage => driver.FindElement(By.XPath("//div[@class='toast-message']"));

    



    }
}
