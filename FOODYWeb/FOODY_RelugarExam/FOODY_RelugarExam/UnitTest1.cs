using FOODY_RelugarExam.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FOODY_RelugarExam
{
    public class Tests
    {
        IWebDriver driver;
        public string LastFoodName;
        public string LastFoodDescribtion;
        public BasePage basePage;
        public LoginPage loginPage;
        public AddFood addFood;
        public AllFoodPage allFoodPage;
        public EditPage editFood;
        public SearchPage searchPage;


        [OneTimeSetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            basePage = new BasePage(driver);
            loginPage = new LoginPage(driver);
            addFood = new AddFood(driver);
            allFoodPage = new AllFoodPage(driver);
            editFood = new EditPage(driver);
            searchPage = new SearchPage(driver);

            //LOGIN
            basePage.OpenPageBaseUrl();
            loginPage.OpenLoginPage();
            loginPage.LoginMethod("atanasgrozev", "123456");
            loginPage.LoginButton.Click();
        }
        public void ScrollToElementAndClick(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
            actions.Click(element).Perform();
        }
        public void ScrollToElement(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
           
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public string GenerateRandomTitie()
        {
            var random = new Random();
            return "title".ToUpper() + random.Next(100, 1000);
        }
        public string GenerateRandomDesccription()
        {
            var random = new Random();
            return "DESCRIPTION" + random.Next(100, 1000);
        }

        [Test, Order(1)]
        public void Add_Food_With_Invalid_Data_Test()
        {
            addFood.OpenAddFoodUrl();
            addFood.AddFoodMethod("", "");
            ScrollToElementAndClick(addFood.AddButton);

            Assert.That(driver.Url, Is.EqualTo(addFood.Url));
            Assert.That(addFood.UnableError.Text, Is.EqualTo("Unable to add this food revue!"));
            Assert.That(addFood.NameError.Text, Is.EqualTo("The Name field is required."));
            Assert.That(addFood.DescribeError.Text, Is.EqualTo("The Description field is required."));


        }
        [Test, Order(2)]
        public void Add_Random_Food_Test()
        {
          LastFoodName = GenerateRandomTitie();
            LastFoodDescribtion = GenerateRandomDesccription();

            addFood.OpenAddFoodUrl();
            addFood.AddFoodMethod(LastFoodName, LastFoodDescribtion);
            ScrollToElementAndClick(addFood.AddButton);

            ScrollToElement(allFoodPage.LastFoodTitle);
            Assert.That(driver.Url, Is.EqualTo(allFoodPage.UrlAllFood));
            Assert.That(allFoodPage.LastFoodTitle.Text, Is.EqualTo(LastFoodName));        


        }
        [Test, Order(3)]
        public void Edit_Last_Added_Food_Test()
        {
         
            driver.Navigate().GoToUrl(allFoodPage.UrlAllFood);
            ScrollToElementAndClick(allFoodPage.EditButton);          
            editFood.EditFoodMethod("EDITED TITLE", "EDITED DESCRIBTION");
            editFood.AddButton.Click();           
            string expectedTitle = LastFoodName;          
            string actualTitle = allFoodPage.LastFoodTitle.Text;

          
            if (actualTitle == expectedTitle)
            {
                Console.WriteLine("Verify that the title remains unchanged: The title has not changed.");
            }
            else
            {
                Console.WriteLine("The title has changed.");
            }
          
            Assert.IsTrue(actualTitle == expectedTitle);
        }
        [Test, Order(4)]
        public void Search_food_Title_Test()
        {
            driver.Navigate().GoToUrl(allFoodPage.UrlAllFood);
            ScrollToElement(searchPage.SearchField);
            searchPage.SearchField.Clear();
            searchPage.SearchField.SendKeys(LastFoodName);
            searchPage.SearchButton.Click();
            Assert.That(allFoodPage.AllFoods.Count, Is.EqualTo(1));
            Assert.That(allFoodPage.LastFoodTitle.Text, Is.EqualTo(LastFoodName));          


        }
        [Test, Order(5)]
        public void Delete_Last_Add_Food_Test()
        {
            // driver.Navigate().GoToUrl(allFoodPage.UrlAllFood);
            basePage.OpenPageBaseUrl();
            var countFood = allFoodPage.AllLastFoodTitle.Count();
            ScrollToElement(allFoodPage.LastFoodTitle);
            ScrollToElementAndClick(allFoodPage.DeleteButton);


    
            var actualCountFood = allFoodPage.AllLastFoodTitle.Count();


            Assert.That(countFood, Is.GreaterThanOrEqualTo(actualCountFood));
        
 
             bool isFoodDeleted = !allFoodPage.AllFoods.Any(i => i.Text.Contains(LastFoodName));
            Assert.IsTrue(isFoodDeleted, "The idea was not deleted.");

            Assert.That(LastFoodName, Is.Not.EqualTo(allFoodPage.LastFoodTitle.Text));

        }
        [Test, Order(6)]
        public void Search_For_Delete_Food_Test()
        {
           
            basePage.OpenPageBaseUrl();
            ScrollToElement(searchPage.SearchField);
            searchPage.SearchField.Clear();
            searchPage.SearchField.SendKeys(LastFoodName);
            searchPage.SearchButton.Click();

            IWebElement thereIsNoFoodMSG = driver.FindElement(By.XPath("//h2[text()='There are no foods :(']"));           
            Assert.That(thereIsNoFoodMSG.Text, Is.EqualTo("There are no foods :("));

            bool isAddButtonPresent = false;
            try
            {             
                IWebElement addButton = driver.FindElement(By.XPath("//a[@class='btn btn-primary btn-xl rounded-pill mt-5']"));
                isAddButtonPresent = true; 
            }
            catch (NoSuchElementException)
            {
             
            }
                     
            Assert.IsTrue(isAddButtonPresent);
        }

    }
}