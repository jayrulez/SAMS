using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Infrastructure.Managers;
using WebApi.Infrastructure.DataStores;

namespace WebApi.Tests
{
    [TestClass]
    public class CreateUserTest
    {
        [TestMethod]
        public void CreateUser()
        {
            var userManager = new UserManager(new UserStore());
        }
    }
}
