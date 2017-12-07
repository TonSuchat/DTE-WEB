using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTE.Controllers;
using System.Web.Mvc;

namespace DTE.Tests
{
    [TestClass]
    public class AccountControllerTests
    {

        private AccountController accountCtrl;

        [TestInitialize]
        public void Initial()
        {
            accountCtrl = new AccountController();
        }

        [TestMethod]
        public void LogInTest()
        {
            var result = accountCtrl.LogIn(new LogInViewModel() { UserName = "admin", Password = "password" }) as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

    }
}
