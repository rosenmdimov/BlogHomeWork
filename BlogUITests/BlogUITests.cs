using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TestStack.Seleno.Configuration;

namespace BlogUITests
{
    [TestFixture]
    public static class BlogUITests
    {
        public static class BrowserHost
        {
            public static readonly SelenoHost Instance = new SelenoHost();
            public static readonly string RootUrl = @"http://localhost/Article/List";
            static BrowserHost()
            {
                Instance.Run("Blog", 60639);

            }
        }



        //[Test]
        //[Property("Smoke test",1)]
        //[Author("Rossen Dimov")]
        //public void CheckSiteLoad()
        //{
        //    IWebDriver driver = new ChromeDriver();
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        //
        //    driver.Navigate().GoToUrl(@"http://localhost:60634/Article/List");
        //
        //    var logo = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
        //    Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        //}
    }
}
