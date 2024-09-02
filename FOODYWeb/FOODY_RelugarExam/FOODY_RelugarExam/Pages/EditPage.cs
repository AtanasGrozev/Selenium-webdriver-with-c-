using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOODY_RelugarExam.Pages
{
    public class EditPage : BasePage
    {

        public EditPage(IWebDriver driver) : base(driver)
        {
            
        }
        public IWebElement FoodNameField => driver.FindElement(By.XPath("//input[@id='name']"));
        public IWebElement DescribeFoodField => driver.FindElement(By.XPath("//input[@id='description']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));

        public void EditFoodMethod(string foodname, string foodescribtion)
        {
            FoodNameField.Clear();
            FoodNameField.SendKeys(foodname);
            DescribeFoodField.Clear();
            DescribeFoodField.SendKeys(foodescribtion);

        }
    }
}
