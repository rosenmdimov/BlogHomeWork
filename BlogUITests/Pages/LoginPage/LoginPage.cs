using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BlogBuild.Tests.Models;

namespace BlogBuild.Tests.Pages.LoginPage
{
    public partial class LoginPage : BasePage
    {


        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public string URL
        {
            get
            {
                return base.url + "Account/Login";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }



        public void Login(User user)
        {
            var loginPage = new LoginPage(this.Driver);

            loginPage.NavigateTo();
            loginPage.Type(loginPage.Email, user.Email);
            loginPage.Type(loginPage.Password, user.Password);
            loginPage.LoginButton.Click();

        }
    }
}