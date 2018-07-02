using BlogBuild.Tests.Models;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.IO;

namespace BlogBuild.Tests.Pages.HomePage.HomePageTests
{
    [TestFixture]
    class HomePageTests
    {


            private IWebDriver driver;

            [SetUp]
            public void Init()
            {
                //this.driver = new InternetExplorerDriver();
                this.driver = new ChromeDriver();
            }
           [TearDown]
           public void CleanUp()
           {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var path = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                File.WriteAllText(path, TestContext.CurrentContext.Test.FullName + " " + TestContext.CurrentContext.TestDirectory);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(path + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }
            this.driver.Quit();
           }

            [Test]
            [Property("Smoke test", 1)]
            [Author("Rossen Dimov")]

            public void HomePageIsLoaded ()
            {
                var homePage = new HomePage(this.driver);

               // var count = homePage.PostContainer.FindElements(By.ClassName("col-sm-6"));
            //count.Count();
            homePage.NavigateTo();
            var logo = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
            
            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        }
            [Test]
            [Property("Integration Test", 1)]
            [Author("Rossen Dimov")]

            public void CreateNewPost()
            {
            var user = AccessExcelData.GetTestData("TryToLoggingIn");
            var accountPage = new AccountPage.AccountPage(this.driver);
            var loginPage = new LoginPage.LoginPage(this.driver);
            var createPostPage = new CreatePostPage.CreatePostPage(this.driver);
            accountPage.NavigateTo();
            if (accountPage.LoginLink.Displayed)
            {
                accountPage.LoginLink.Click();

                loginPage.NavigateTo();
                loginPage.Login(user);
            }

            createPostPage.CreateNewPost();

            var logo = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
                Assert.AreEqual("SOFTUNI BLOG", logo.Text);

                //Assert.AreNotEqual(postsNumber.Size, homePage.PostContainer);

            }
        [Test]
        [Property("Integration Test", 1)]
        [Author("Rossen Dimov")]
        public void DeletePost()
        {
            var user = AccessExcelData.GetTestData("TryToLoggingIn");
            var accountPage = new AccountPage.AccountPage(this.driver);
            var loginPage = new LoginPage.LoginPage(this.driver);
            //  string newPostLink = accountPage.FindNewPostTitle.Text;
            // try
            // {
            loginPage.Login(user);
            accountPage.NavigateTo();
            var postCountbefore = this.driver.FindElements(By.TagName("a"));

            accountPage.FindNewPostTitle.Click();
            
            this.driver.FindElement(By.PartialLinkText("Delete")).Click();
            
            this.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input")).Click();
            Assert.AreEqual(postCountbefore.Count-1, this.driver.FindElements(By.TagName("a")).Count);
            //    if(accountPage.FindNewPostTitle.Text == null)
            //     {
            //         CreatePostPageAsserter.AsserterForMissingElement("NoSuchElementException");
            //     }
            // }
            // catch (NoSuchElementException )
            // {
            //     CreatePostPageAsserter.AsserterForMissingElement("NoSuchElementException");
            //     
            // }







        }

    }
   
}
