using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOODY_RelugarExam.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver): base(driver)
        {

            
        }
        public IWebElement SearchField => driver.FindElement(By.XPath("//input[@class='form-control rounded mt-5 xl']"));
        public IWebElement SearchButton => driver.FindElement(By.XPath("//button[@type='submit']"));



    }
}
