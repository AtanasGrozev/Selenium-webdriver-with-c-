using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOODY_RelugarExam.Pages
{
    public class AddFood : BasePage
    {

        public AddFood(IWebDriver driver): base(driver)
        {
            
        }
        public string Url => BaseUrl + "Food/Add";

        public void OpenAddFoodUrl()
        {
            driver.Navigate().GoToUrl(Url);
        }
        public IWebElement FoodNameField => driver.FindElement(By.XPath("//input[@id='name']"));
        public IWebElement DescribeFoodField => driver.FindElement(By.XPath("//input[@id='description']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));
         //ERROR MESSAGE
        public IWebElement UnableError => driver.FindElement(By.XPath("//li[text()='Unable to add this food revue!']"));
        public IWebElement NameError => driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and text()='The Name field is required.']"));
        public IWebElement DescribeError => driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and text()='The Description field is required.']")); 


        public void AddFoodMethod(string foodname, string foodescribtion)
        {
            FoodNameField.Clear();
            FoodNameField.SendKeys(foodname);
            DescribeFoodField.Clear();
            DescribeFoodField.SendKeys(foodescribtion);

        }




    }
}
