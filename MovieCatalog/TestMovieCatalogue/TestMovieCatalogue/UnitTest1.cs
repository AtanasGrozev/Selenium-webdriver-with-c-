using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TestMovieCatalogue.Pages;

namespace TestMovieCatalogue
{
    public class Tests
    {
        public IWebDriver driver;
        public BasePage basepage;
        public AddMoviePage addMoviePage;
        public LoginPage loginPage;
        public string LastMovieTitle ;
        public string LastMovieDescription ;
        public AllMoviePage allMoviePage;
        public EditPage editPage;
        public WatchedMoviePAge watchedMoviePage;
        public DeletePage deletePage;


        [OneTimeSetUp]
        public void Setup()
        {       
         
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            addMoviePage = new AddMoviePage(driver);
            loginPage = new LoginPage(driver);
            basepage = new BasePage(driver);
            allMoviePage = new AllMoviePage(driver);
            editPage = new EditPage(driver);
            watchedMoviePage = new WatchedMoviePAge(driver);
            deletePage 
                = new DeletePage(driver);

            //LOGIN
            basepage.OpenPageBaseUrl();
            loginPage.OpenPageLogin();
            loginPage.LoginMethod("atanas@test.bg", "123456");
            loginPage.LoginButton.Click();

        }
        public void ScrollToElementAndClick(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform(); 
            actions.Click(element).Perform(); 
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
        public void Add_Movie_Without_Title_Test()
        {
            LastMovieTitle = GenerateRandomTitie();
            LastMovieDescription = GenerateRandomDesccription();
            addMoviePage.OpenPageAddMovie();
            addMoviePage.AddMovieMethod("", LastMovieDescription);
            ScrollToElementAndClick(addMoviePage.AddButton);
           
            Assert.That(addMoviePage.ErrorTitleField.Text, Is.EqualTo("The Title field is required."));
        
        }
        [Test, Order(2)]
        public void Add_Movie_Without_Description_Test()
        {
            LastMovieTitle = GenerateRandomTitie();
            LastMovieDescription = GenerateRandomDesccription();
            addMoviePage.OpenPageAddMovie();
            addMoviePage.AddMovieMethod(LastMovieTitle, "");
            ScrollToElementAndClick(addMoviePage.AddButton);

            Assert.That(addMoviePage.ErrorTitleField.Text, Is.EqualTo("The Description field is required."));

        }
        [Test, Order(3)]
        public void Add_Movie_with_Random_Title_Test()
        {
            LastMovieTitle = GenerateRandomTitie();
            LastMovieDescription = GenerateRandomDesccription();

            addMoviePage.OpenPageAddMovie();
            addMoviePage.AddMovieMethod(LastMovieTitle, LastMovieDescription);
            ScrollToElementAndClick(addMoviePage.AddButton);
            allMoviePage.NavigateTolastPage();

            Assert.That(LastMovieTitle,Is.EqualTo(allMoviePage.LastMovieTitle.Text));

        }
        [Test, Order(4)]
        public void Edit_Last_Add_Movie_test()
        {
            basepage.OpenPageBaseUrl();
            allMoviePage.OpenPageAllMovie();
            allMoviePage.NavigateTolastPage();
            ScrollToElementAndClick(allMoviePage.EditButton);
            LastMovieTitle =  GenerateRandomTitie() + " UPDATED";
            editPage.EditMovieMethod(LastMovieTitle, LastMovieDescription);
            ScrollToElementAndClick(editPage.EditButton);
            allMoviePage.NavigateTolastPage();

            Assert.That(LastMovieTitle.ToUpper, Is.EqualTo(allMoviePage.LastMovieTitle.Text));

        }
        [Test, Order(5)]
        public void Mark_Last_Added_movie_as_watched_test()
        {
            basepage.OpenPageBaseUrl();
            allMoviePage.OpenPageAllMovie();
            allMoviePage.NavigateTolastPage();
            ScrollToElementAndClick(allMoviePage.MarkAsWatchedButton);
            watchedMoviePage.OpePageWatchedMovie();
            allMoviePage.NavigateTolastPage();

            Assert.That(LastMovieTitle.ToUpper, Is.EqualTo(watchedMoviePage.LastMovieTitle.Text));






        }
        [Test, Order(6)]
        public void Delete_Last_Added_Movie_Page_test()
        {
            basepage.OpenPageBaseUrl();
            allMoviePage.OpenPageAllMovie();
            allMoviePage.NavigateTolastPage();
            ScrollToElementAndClick(allMoviePage.DeleteButton);
            ScrollToElementAndClick(deletePage.DeleteButton);

            Assert.That(deletePage.DeleteMessage.Text, Is.EqualTo("The Movie is deleted successfully!"));

        }


    }
}