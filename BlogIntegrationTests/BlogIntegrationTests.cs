using BlogBuild.Tests.Pages.AccountPage;
using BlogBuild.Tests.Pages.CreatePostPage;
using BlogBuild.Tests.Pages.HomePage;
using BlogBuild.Tests.Pages.LoginPage;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests

{

    [TestFixture]
    public class BlogIntegrationTests
    {
        private IWebDriver driver;

        [SetUp]

        public void Init()
        {
            //this.driver = new InternetExplorerDriver();
            this.driver = new ChromeDriver();
        }

        //[TearDown]
        //public void CleanUp()
        //{
        //    this.driver.Quit();
        //}
        //
        //[Test]
        //[Property("Integration Test", 1)]
        //[Author("Rossen Dimov")]
        //
        //public void CreateNewPost1()
        //{
        //    var accountPage = new AccountPage(this.driver);
        //    accountPage.NavigateTo();
        //
        //    var logo = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
        //    Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        //
        //    //Assert.AreNotEqual(postsNumber.Size, homePage.PostContainer);
        //
        //}
        //
      // [Test]
      // [Property("Integration Test", 1)]
      // [Author("Rossen Dimov")]
      //
      // public void CreateNewPost()
      // {
      //     var accountPage = new AccountPage(this.driver);
      //     
      //     
      //     //var homePage = new HomePage(this.driver);
      //     accountPage.NavigateTo();
      //     if(accountPage.LoginLink.Displayed)
      //     {
      //         accountPage.LoginLink.Click();
      //         var loginPage = new LoginPage(this.driver);
      //         loginPage.NavigateTo();
      //         loginPage.Login();
      //     }
      //     //accountPage.CreateNewPost.Click();
      //     var createPostPage = new CreatePostPage(this.driver);
      //     createPostPage.CreateNewPost();
      //
      //     var logo = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
      //     Assert.AreEqual("SOFTUNI BLOG", logo.Text);
      //
      //     //Assert.AreNotEqual(postsNumber.Size, homePage.PostContainer);
      //
      // }

      // [Test]
      //[Property("Integration Test", 1)]
      //[Author("Rossen Dimov")]
      // public void DeletePost()
      // {
      //     var loginPage = new LoginPage(this.driver);
      //     var accountPage = new AccountPage(this.driver);
      //    
      //   //  string newPostLink = accountPage.FindNewPostTitle.Text;
      //    // try
      //    // {
      //         loginPage.Login();
      //     accountPage.NavigateTo();
      //     accountPage.FindNewPostTitle.Click();
      //         this.driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]")).Click();
      //         this.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input")).Click();
      //     //    if(accountPage.FindNewPostTitle.Text == null)
      //    //     {
      //    //         CreatePostPageAsserter.AsserterForMissingElement("NoSuchElementException");
      //    //     }
      //    // }
      //    // catch (NoSuchElementException )
      //    // {
      //    //     CreatePostPageAsserter.AsserterForMissingElement("NoSuchElementException");
      //    //     
      //    // }
      //
      //
      //
      //
      //
      //
      //
      // }
    }
}
