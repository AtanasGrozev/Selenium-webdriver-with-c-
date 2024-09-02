using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOODY_RelugarExam.Pages
{
    public class BasePage
    {
       public  IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            
        }
        public string BaseUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";

        public void OpenPageBaseUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public IWebElement LogInLink => driver.FindElement(By.XPath("//a[@class='nav-link' and text()='Log In']"));


    }
}
