using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestIdeaCenter.Pages;

namespace TestIdeaCenter.Tests
{
    public class Tests
    {
        public IWebDriver driver;
        public CreateIdeaPages createIdeaPages;
        public EditPage editPage;
        public LoginPage loginPage;
        public MyIdeasPage myIdeasPage;
        public ViewIdeaPagte viewIdeaPage;

        public static string randomTitle;
        public static string randomDescription;

        public string editedTitle;
        public string editedDescription;

        [OneTimeSetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);


            loginPage = new LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login("atanas@test.bg", "123456");

            createIdeaPages = new CreateIdeaPages(driver);
            myIdeasPage = new MyIdeasPage(driver);
            viewIdeaPage = new ViewIdeaPagte(driver);
            editPage = new EditPage(driver);

        }

        [OneTimeTearDown]
        public void TearDown()

        {
            driver.Quit();
            driver.Dispose();
        }

        public string GenerateRandomString(int length)
        {
            return Guid.NewGuid().ToString("N").Substring(0, length);
        }


        [Test, Order(1)]
        public void CreateIdeaWithInvalidDataTest()
        {

            createIdeaPages.Openpage();
            createIdeaPages.CreateIdea("", "");


            Assert.That(driver.Url, Is.EqualTo(createIdeaPages.Url));
            Assert.That(createIdeaPages.UnableErrorMessage.Text, Is.EqualTo("Unable to create new Idea!"));
            Assert.That(createIdeaPages.TitleErrorMessage.Text, Is.EqualTo("The Title field is required."));
            Assert.That(createIdeaPages.DescriptionErrorMessage.Text, Is.EqualTo("The Description field is required."));


        }
        [Test, Order(2)]
        public void CreateIdeaWithValidDataTest()
        {

            randomTitle = GenerateRandomString(3) + " Title";
            randomDescription = GenerateRandomString(3) + " Description";
            createIdeaPages.Openpage();
            createIdeaPages.CreateIdea(randomTitle, randomDescription);

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url));
            Assert.That(myIdeasPage.DescriptionLastIdea.Text.Trim(), Is.EqualTo(randomDescription));


        }
        [Test, Order(3)]
        public void ViewLastCreatedIdeaTest()
        {
            myIdeasPage.OpnePage();
            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(viewIdeaPage.DescriptionIdea.Text.Trim(), Is.EqualTo(randomDescription.Trim()));
            Assert.That(viewIdeaPage.TitleIdea.Text.Trim(), Is.EqualTo(randomTitle.Trim()));

        }
        [Test, Order(4)]
        public void EditLastCreatedIdeaTest()
        {
            editPage.Openpage();
            myIdeasPage.EditButtonLastIdea.Click();
           editedTitle = "Edited Title";
           editedDescription = "Edited description";

            editPage.EditIdea(editedTitle, editedDescription);

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url));
            Assert.That(myIdeasPage.DescriptionLastIdea.Text.Trim(), Is.EqualTo(editedDescription));
            myIdeasPage.ViewButtonLastIdea.Click();
         
            Assert.That(viewIdeaPage.TitleIdea.Text.Trim(), Is.EqualTo(editedTitle));
            Assert.That(viewIdeaPage.DescriptionIdea.Text.Trim(), Is.EqualTo(editedDescription));

        }
        [Test,Order(5)]
        public void DeleteLastIdeaTest()         
        {

            myIdeasPage.OpnePage();
            myIdeasPage.DeleteButtonLastIdea.Click();

            bool isIdeaDeleted = !myIdeasPage.AllIdeas.Any(i => i.Text.Contains(editedDescription));

            Assert.IsTrue(isIdeaDeleted, "The idea was not deleted.");

        }

     
    }
}