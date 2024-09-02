using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;


namespace TestIdeaCenter.Pages
{
    public class BasePage

    {
        protected IWebDriver driver;
        protected WebDriverWait wait; // забравено


        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
             wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
        }

        protected static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";

        public IWebElement HomeButton => driver.FindElement(By.XPath("//a[@class='navbar-brand me-2']"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("btn btn-outline-info px-3 me-2"));
        public IWebElement SingUpButton => driver.FindElement(By.XPath("btn btn-primary me-3"));
        public IWebElement IdeaCenterButton => driver.FindElement(By.XPath("//a[@class='nav-link']"));
        public IWebElement MyProfileButton => driver.FindElement(By.XPath("//a[@class='nav-link' and text()='My Profile']"));
        public IWebElement MyIdeasButton => driver.FindElement(By.XPath("//a[@class='nav-link' and text()='My Ideas']"));
        public IWebElement CreateIdeaButton => driver.FindElement(By.XPath("//a[@class='nav-link' and text()='Create Idea']"));
        public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[@class='btn btn-primary me-3']"));

     

    }
}
