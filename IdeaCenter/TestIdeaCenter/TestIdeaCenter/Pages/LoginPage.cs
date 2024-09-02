using OpenQA.Selenium;

namespace TestIdeaCenter.Pages
{
    public class LoginPage : BasePage
    {



        public LoginPage(IWebDriver driver) : base(driver)
        {

        }
        public string Url = BaseUrl + "/Users/Login";
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);

        }

        public IWebElement EmailField => driver.FindElement(By.XPath("//input[@id='typeEmailX-2']"));
        public IWebElement PasswordField => driver.FindElement(By.XPath("//input[@id='typePasswordX-2']"));
        public IWebElement SingInButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block'][@type='submit']"));


        public void Login(string email, string passwrd)
        {
            EmailField.SendKeys(email);
            PasswordField.SendKeys(passwrd);
            SingInButton.Click();

        }





        //ERROR MESSAGE LOCATORS//
        public IWebElement EmailErrorMessage => driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and text()='The e-mail is required!']"));
        public IWebElement PasswordErrorMessage => driver.FindElement(By.XPath("//span[@class='text-danger field-validation-error' and text()='The password is required!']"));
        public IWebElement UnableErrorMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']"));


   

     




    }
}
