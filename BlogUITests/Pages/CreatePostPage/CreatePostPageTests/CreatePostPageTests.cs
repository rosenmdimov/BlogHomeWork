using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBuild.Tests.Pages.CreatePostPage.CreatePostPageTests
{
    [TestFixture]

    class CreatePostPageTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            //this.driver = new InternetExplorerDriver();
            this.driver = new ChromeDriver();
        }

        [Test]
        [Property ("Create New Post",1)]

        public void CreateNewPost()
        {
            var loginPage = new LoginPage.LoginPage(this.driver);
            var accountPage = new AccountPage.AccountPage(this.driver);
            var createPostPage = new CreatePostPage(this.driver);
            string titleOfPost = "New Important Post";
            string contentOfPost = "That is new post created";

            loginPage.Login();

            createPostPage.NavigateTo();
            //loginPage.CreateButton.Click();
            createPostPage.Type(createPostPage.Title,titleOfPost );
            createPostPage.Type(createPostPage.Content, contentOfPost);
            createPostPage.CreatelButton.Click();




        }
        


    }
}
