using OpenQA.Selenium;

namespace TestIdeaCenter.Pages
{
    public  class CreateIdeaPages : BasePage
    {

        public CreateIdeaPages(IWebDriver driver) : base(driver)
        {            
        }

        public string Url = BaseUrl + "/Ideas/Create";

        public void Openpage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public IWebElement CreateIdeaTitle => driver.FindElement(By.XPath("//input[@id='form3Example1c']"));
        public IWebElement CreateIdeaDescribtion => driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));
        public IWebElement CreateButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));


        public void CreateIdea(string title, string description)
        {
            CreateIdeaTitle.SendKeys(title);
            CreateIdeaDescribtion.SendKeys(description);
            CreateButton.Click();

        }


        //ERROR MESSAGE LOCATORS//
        public IWebElement TitleErrorMessage => driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and text()='The Title field is required.']"));
        public IWebElement DescriptionErrorMessage => driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and text()='The Description field is required.']"));
        public IWebElement UnableErrorMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']"));


    }
}
