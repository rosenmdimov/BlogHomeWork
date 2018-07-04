using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBuild.Tests.Pages.RegisterPage
{
    public partial class RegisterPage
    {
        public IWebElement Title
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//div/div/h2"));
            }
        }
        public IWebElement EmailField
        {
            get
            {
                return this.Driver.FindElement(By.Id("Email"));
            }
        }
        public IWebElement FullNameField
        {
            get
            {
                return this.Driver.FindElement(By.Id("FullName"));
            }
        }
        public IWebElement PassworField
        {
            get
            {
                return this.Driver.FindElement(By.Id("Password"));
            }
        }
        public IWebElement ConfirmPasswordField
        {
            get
            {
                return this.Driver.FindElement(By.Id("ConfirmPassword"));
            }
        }
        public IWebElement RegisterButton
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("btn btn-default"));
            }
        }
    }
}
