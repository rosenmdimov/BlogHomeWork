using BlogBuild.Tests.Models;
using BlogBuild.Tests.Pages.AccountPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.IO;

namespace BlogBuild.Tests.Pages.LoginPage.LoginPageTests
{
    [TestFixture]
    class LoginPageTests
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
        [Property("UITest Login loaded", 1)]
        [Author("Rossen Dimov")]

        public void LoginPageLoaded()
        {
            var loginPage = new LoginPage(this.driver);

            loginPage.NavigateTo();

            loginPage.AssertLoginPageLoaded("Log in");
        }

        [Test]
        [Property("User Is Logged In", 1)]
        [Author("Rossen Dimov")]
        public void TryToLoggingIn()
        {
            var user = AccessExcelData.GetTestData("TryToLoggingIn");
            var loginPage = new LoginPage(this.driver);
            var accountPage = new AccountPage.AccountPage(this.driver);

            accountPage.NavigateTo();
            accountPage.LoginLink.Click();
            loginPage.Login(user);

            accountPage.AssertIsLogged("Hello abv@abv.bg!");
        }
        [Test]
        [Property("Login With Invalid Username", 1)]
        [Author("Rossen Dimov")]
        public void LoginWithInvalidUser()
        {
            var user = AccessExcelData.GetTestData("LoginWithInvalidUser");
            var loginPage = new LoginPage(this.driver);
            var accountPage = new AccountPage.AccountPage(this.driver);

            accountPage.NavigateTo();
            accountPage.LoginLink.Click();
            loginPage.Login(user);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            loginPage.AssertErrorMessageForMail("The Email field is not a valid e-mail address.");
        }

      //  [Test]
      //  [Property("Login Without Password", 1)]
      //  [Author("Rossen Dimov")]
      //  public void LoginWithoutPassword()
      //  {
      //      var user = AccessExcelData.GetTestData("LoginWithoutPassword");
      //      var loginPage = new LoginPage(this.driver);
      //      var accountPage = new AccountPage.AccountPage(this.driver);
      //
      //      accountPage.NavigateTo();
      //      accountPage.LoginLink.Click();
      //      loginPage.Login(user);
      //      WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
      //      loginPage.AssertErrorMessageForPassword("Invalid login attempt.");
      //  }
    }
}

