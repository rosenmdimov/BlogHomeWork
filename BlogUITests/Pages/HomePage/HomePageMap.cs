using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBuild.Tests.Pages.HomePage
{
    public partial class HomePage
    {
        public IWebElement HomeTitle
        {
            get
            {
                return this.Driver.FindElement(By.Name("Title"));
            }

        }
        public IWebElement RegisterLink
        {
            get
            {
                return this.Driver.FindElement(By.Id("registerLink"));

            }
        }
        public IWebElement LoginLink
        {
            get
            {
                return this.Driver.FindElement(By.Id("loginLink"));

            }
        }
        
        public IWebElement HomeLink
        {
            get
            {
                return this.Driver.FindElement(By.LinkText("SOFTUNI BLOG"));

            }
        }
        public IWebElement PostContainer
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("row"));
            }
         }
    }
}
