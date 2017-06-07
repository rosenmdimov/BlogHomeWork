using BlogBuild.Tests.Models;
using BlogBuild.Tests.Pages.AccountPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var path = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                File.WriteAllText(path, TestContext.CurrentContext.Test.FullName + " " + TestContext.CurrentContext.TestDirectory);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(path + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }
            this.driver.Quit();
        }





        [Test]
        [Property ("UITest Login loaded",1)]
        [Author("Rossen Dimov")]

        public void LoginPageLoaded()
        {
            var loginPage = new LoginPage(this.driver);

            loginPage.NavigateTo();

            loginPage.AssertLoginPageLoaded("Log in");
        }

        [Test]
        [Property ("User Is Logged In",1)]
        [Author("Rossen Dimov")]
        public void TryToLoggingIn()
        {
            var user = AccessExcelData.GetTestData("Login");
            var loginPage = new LoginPage(this.driver);
            var accountPage = new AccountPage.AccountPage(this.driver);
            accountPage.NavigateTo();
            accountPage.LoginLink.Click();
            loginPage.Login(user);
 
            accountPage.AssertIsLogged("Hello abv@abv.bg!");
        }
    }
}
