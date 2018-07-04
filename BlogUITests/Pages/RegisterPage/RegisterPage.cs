using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BlogBuild.Tests.Pages.RegisterPage
{
    public partial class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver)
        {
        }
        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }
        public string URL
        {
            get
            {
                return base.url + "Account/Register";
            }
        }
    }
}
