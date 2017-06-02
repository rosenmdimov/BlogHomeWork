using BlogBuild.Tests.Pages.AccountPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

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
            this.driver.Quit();
        }


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
