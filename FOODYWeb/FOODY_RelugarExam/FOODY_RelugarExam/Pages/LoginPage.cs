
using OpenQA.Selenium;


namespace FOODY_RelugarExam.Pages
{
    public class LoginPage : BasePage
    {

        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }


     
        public string UrlLoginPage => BaseUrl + "User/Login";

        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(UrlLoginPage);
        }

        public IWebElement UserNameField => driver.FindElement(By.XPath("//input[@id='username']"));
        public IWebElement PasswordNameField => driver.FindElement(By.XPath("//input[@id='password']"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));

        public void LoginMethod(string username, string passwrod)
        {
            UserNameField.Clear();
            UserNameField.SendKeys(username);
            PasswordNameField.Clear();
            PasswordNameField.SendKeys(passwrod);

        }


    }

}
