using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOODY_RelugarExam.Pages
{
    public class AllFoodPage : BasePage 
    {

        public AllFoodPage(IWebDriver driver) : base(driver)
        {
            
        }
        public string UrlAllFood => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";
        public void OpenPageAllFood()
        {
            driver.Navigate().GoToUrl(UrlAllFood);
        }      
   

        public ReadOnlyCollection<IWebElement> AllFoods => driver.FindElements(By.XPath("//div[@class='col-lg-6 order-lg-1']"));
     
        public IWebElement LastFood => AllFoods.Last();
        public ReadOnlyCollection<IWebElement> AllLastFoodTitle => LastFood.FindElements(By.XPath("//h2[@class='display-4']"));
   

        //LAST 
        public IWebElement LastFoodTitle => AllLastFoodTitle.Last();
        public IWebElement EditButton => LastFood.FindElement(By.XPath(".//a[@class='btn btn-primary btn-xl rounded-pill mt-5' and text()='Edit']"));
        public IWebElement DeleteButton => LastFood.FindElement(By.XPath(".//a[@class='btn btn-primary btn-xl rounded-pill mt-5' and text()='Delete']"));
     

    }
}
