using OpenQA.Selenium;


namespace TestMovieCatalogue.Pages
{
    public class LoginPage : BasePage
    {

        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string UrlLoginPage => BaseUrl + "User/Login";
        public void OpenPageLogin()
        {
            driver.Navigate().GoToUrl(UrlLoginPage);
        }

        public IWebElement EmailAdressFiled => driver.FindElement(By.XPath("//input[@type='email']"));
        public IWebElement PasswrodField => driver.FindElement(By.XPath("//input[@type='password']"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[@type='submit']"));


        public void LoginMethod(string email, string passwrod)
        {
            EmailAdressFiled.Clear();
            EmailAdressFiled.SendKeys(email);
            PasswrodField.Clear();
            PasswrodField.SendKeys(passwrod);

        }
    }
}
