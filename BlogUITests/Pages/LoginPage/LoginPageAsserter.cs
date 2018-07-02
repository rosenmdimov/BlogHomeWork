﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogBuild.Tests.Pages.AccountPage;

namespace BlogBuild.Tests.Pages.LoginPage
{
    public static class  LoginPageAsserter
    {

        public static void AssertLoginPageLoaded(this LoginPage page, string text  )
        {
            Assert.AreEqual(text, page.Heading.Text);
        }
        public static void AssertErrorMessageForMail(this LoginPage page, string text)
        {
            Assert.AreEqual(text, page.ErrorEmailMessage.Text);
        }
        public static void AssertErrorMessageForPassword(this LoginPage page, string text)
        {
            Assert.AreEqual(text, page.ErrorPasswordMessage.Text);
        }

    }
}
