using BlogBuild.Tests.Pages.AccountPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.IO;

namespace BlogUITests
{
    [TestFixture]
    public class BlogUITests
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
        //

        [Test]
        [Property("Smoke test",1)]
        [Author("Rossen Dimov")]
        public void CheckSiteLoad()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            var accountPage = new AccountPage(this.driver);
            accountPage.NavigateTo();

            var logo = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
            driver.Close();
        }
    }
}
