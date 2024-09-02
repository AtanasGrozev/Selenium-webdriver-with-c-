using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIdeaCenter.Pages
{
    public class ViewIdeaPagte : BasePage
    {

        public ViewIdeaPagte(IWebDriver driver): base(driver)
        {
            
        }

        public string Url = BaseUrl + "/Ideas/Read";
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url); 
        }

        public IWebElement TitleIdea => driver.FindElement(By.XPath("//h1[@class='mb-0 h4']"));
        public IWebElement DescriptionIdea => driver.FindElement(By.XPath("//p[@class='offset-lg-3 col-lg-6']"));

    }
}
