using Microsoft.VisualStudio.TestTools.UnitTesting;
using N9.Services.Implementations;
using N9.Data;
using System;

namespace N9.Tests
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        private AuthenticationService _authService;

        [TestInitialize]
        public void Setup()
        {
            // Initialize database for tests
            DatabaseInitializer.Initialize();
            _authService = new AuthenticationService();
        }

        [TestMethod]
        public void Login_WithEmptyCredentials_ShouldFail()
        {
            var result = _authService.Login("", "");
            
            Assert.IsFalse(result.Success);
            Assert.IsNotNull(result.Message);
        }

        [TestMethod]
        public void Login_WithNonExistentUser_ShouldFail()
        {
            var result = _authService.Login("nonexistent_user_" + Guid.NewGuid(), "password");
            
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void Register_WithValidCredentials_ShouldSucceed()
        {
            var username = "testuser_" + Guid.NewGuid().ToString().Substring(0, 8);
            var password = "TestPass123";
            var email = "test@example.com";
            
            var result = _authService.Register(username, password, email);
            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Register_WithEmptyUsername_ShouldFail()
        {
            var result = _authService.Register("", "password", "email@test.com");
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Register_WithEmptyPassword_ShouldFail()
        {
            var result = _authService.Register("username", "", "email@test.com");
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Register_DuplicateUsername_ShouldFail()
        {
            var username = "duplicate_" + Guid.NewGuid().ToString().Substring(0, 8);
            var password = "TestPass123";
            
            _authService.Register(username, password, "email1@test.com");
            var result = _authService.Register(username, password, "email2@test.com");
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Login_AfterRegister_ShouldSucceed()
        {
            var username = "logintest_" + Guid.NewGuid().ToString().Substring(0, 8);
            var password = "TestPass123";
            
            _authService.Register(username, password, "email@test.com");
            var result = _authService.Login(username, password);
            
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.User);
        }

        [TestMethod]
        public void Login_WithWrongPassword_ShouldFail()
        {
            var username = "wrongpass_" + Guid.NewGuid().ToString().Substring(0, 8);
            var password = "TestPass123";
            
            _authService.Register(username, password, "email@test.com");
            var result = _authService.Login(username, "WrongPassword");
            
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void ChangePassword_WithCorrectOldPassword_ShouldSucceed()
        {
            var username = "changepass_" + Guid.NewGuid().ToString().Substring(0, 8);
            var oldPassword = "OldPass123";
            var newPassword = "NewPass456";
            
            _authService.Register(username, oldPassword, "email@test.com");
            var loginResult = _authService.Login(username, oldPassword);
            
            var result = _authService.ChangePassword(loginResult.User.Id, oldPassword, newPassword);
            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ChangePassword_WithWrongOldPassword_ShouldFail()
        {
            var username = "changepassfail_" + Guid.NewGuid().ToString().Substring(0, 8);
            var password = "TestPass123";
            
            _authService.Register(username, password, "email@test.com");
            var loginResult = _authService.Login(username, password);
            
            var result = _authService.ChangePassword(loginResult.User.Id, "WrongOldPassword", "NewPass456");
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetCurrentUser_AfterLogin_ShouldReturnUser()
        {
            var username = "currentuser_" + Guid.NewGuid().ToString().Substring(0, 8);
            var password = "TestPass123";
            
            _authService.Register(username, password, "email@test.com");
            _authService.Login(username, password);
            
            var user = _authService.GetCurrentUser();
            
            Assert.IsNotNull(user);
            Assert.AreEqual(username, user.Username);
        }

        [TestMethod]
        public void Logout_ShouldClearCurrentUser()
        {
            var username = "logout_" + Guid.NewGuid().ToString().Substring(0, 8);
            var password = "TestPass123";
            
            _authService.Register(username, password, "email@test.com");
            _authService.Login(username, password);
            _authService.Logout();
            
            var user = _authService.GetCurrentUser();
            
            Assert.IsNull(user);
        }
    }
}
