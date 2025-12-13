using Microsoft.VisualStudio.TestTools.UnitTesting;
using N9.Data;
using N9.Models;
using N9.Repositories.Implementations;
using N9.Services.Implementations;
using System;

namespace N9.Tests
{
    [TestClass]
    public class DatabaseIntegrationTests
    {
        [TestInitialize]
        public void Setup()
        {
            DatabaseInitializer.Initialize();
        }

        [TestMethod]
        public void DatabaseInitializer_ShouldCreateTables()
        {
            // Should not throw exception
            DatabaseInitializer.Initialize();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void CategoryRepository_ShouldReturnSeededCategories()
        {
            var repo = new CategoryRepository();
            var categories = repo.GetAllCategories();
            
            Assert.IsTrue(categories.Count > 0);
        }

        [TestMethod]
        public void CreditCardRepository_CRUD_ShouldWork()
        {
            // Setup - create user first
            var authService = new AuthenticationService();
            var username = "cardtest_" + Guid.NewGuid().ToString().Substring(0, 8);
            authService.Register(username, "TestPass123", "test@test.com");
            var loginResult = authService.Login(username, "TestPass123");
            var userId = loginResult.User.Id;

            var cardRepo = new CreditCardRepository();
            
            // Create
            var card = new CreditCard
            {
                UserId = userId,
                BankName = "Test Bank",
                CardType = "Visa",
                Last4Digits = "1234",
                CreditLimit = 50000000,
                StatementDay = 15,
                DueDayOffset = 15,
                Status = CardStatus.Active,
                CreatedAt = DateTime.Now
            };
            
            var cardId = cardRepo.Add(card);
            Assert.IsTrue(cardId > 0);
            
            // Read
            var savedCard = cardRepo.GetById(cardId);
            Assert.IsNotNull(savedCard);
            Assert.AreEqual("Test Bank", savedCard.BankName);
            
            // Update
            savedCard.BankName = "Updated Bank";
            cardRepo.Update(savedCard);
            var updatedCard = cardRepo.GetById(cardId);
            Assert.AreEqual("Updated Bank", updatedCard.BankName);
            
            // Delete
            cardRepo.Delete(cardId);
            var deletedCard = cardRepo.GetById(cardId);
            Assert.IsNull(deletedCard);
        }

        [TestMethod]
        public void TransactionService_AddTransaction_ShouldCreateStatementPeriod()
        {
            // Setup
            var authService = new AuthenticationService();
            var username = "txtest_" + Guid.NewGuid().ToString().Substring(0, 8);
            authService.Register(username, "TestPass123", "test@test.com");
            var loginResult = authService.Login(username, "TestPass123");
            var userId = loginResult.User.Id;

            var cardRepo = new CreditCardRepository();
            var card = new CreditCard
            {
                UserId = userId,
                BankName = "Test Bank",
                CardType = "Visa",
                Last4Digits = "5678",
                CreditLimit = 50000000,
                StatementDay = 15,
                DueDayOffset = 15,
                Status = CardStatus.Active,
                CreatedAt = DateTime.Now
            };
            var cardId = cardRepo.Add(card);

            var categoryRepo = new CategoryRepository();
            var categories = categoryRepo.GetAllCategories();
            var categoryId = categories[0].Id;

            // Test
            var txService = new TransactionService();
            var transaction = new Transaction
            {
                CardId = cardId,
                TransactionDate = DateTime.Today,
                MerchantName = "Test Merchant",
                Amount = 1000000,
                CategoryId = categoryId,
                IsInstallment = false
            };

            var txId = txService.AddTransaction(transaction);
            Assert.IsTrue(txId > 0);

            // Verify transaction was saved
            var savedTx = txService.GetById(txId);
            Assert.IsNotNull(savedTx);
            Assert.AreEqual("Test Merchant", savedTx.MerchantName);
            Assert.IsNotNull(savedTx.StatementId); // Should be auto-assigned
        }

        [TestMethod]
        public void StatementService_ConfirmPayment_ShouldUpdateStatus()
        {
            // Setup
            var authService = new AuthenticationService();
            var username = "stmttest_" + Guid.NewGuid().ToString().Substring(0, 8);
            authService.Register(username, "TestPass123", "test@test.com");
            var loginResult = authService.Login(username, "TestPass123");
            var userId = loginResult.User.Id;

            var cardRepo = new CreditCardRepository();
            var card = new CreditCard
            {
                UserId = userId,
                BankName = "Test Bank",
                CardType = "Visa",
                Last4Digits = "9012",
                CreditLimit = 50000000,
                StatementDay = 15,
                DueDayOffset = 15,
                Status = CardStatus.Active,
                CreatedAt = DateTime.Now
            };
            var cardId = cardRepo.Add(card);

            var categoryRepo = new CategoryRepository();
            var categories = categoryRepo.GetAllCategories();

            var txService = new TransactionService();
            txService.AddTransaction(new Transaction
            {
                CardId = cardId,
                TransactionDate = DateTime.Today,
                MerchantName = "Test",
                Amount = 500000,
                CategoryId = categories[0].Id
            });

            // Test
            var stmtService = new StatementService();
            var statements = stmtService.GetStatements(cardId);
            Assert.IsTrue(statements.Count > 0);

            var stmt = statements[0];
            var result = stmtService.ConfirmPayment(stmt.Id, stmt.TotalAmount);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReportService_GetSpendingByCategory_ShouldReturnData()
        {
            // Setup
            var authService = new AuthenticationService();
            var username = "reporttest_" + Guid.NewGuid().ToString().Substring(0, 8);
            authService.Register(username, "TestPass123", "test@test.com");
            var loginResult = authService.Login(username, "TestPass123");
            var userId = loginResult.User.Id;

            var cardRepo = new CreditCardRepository();
            var card = new CreditCard
            {
                UserId = userId,
                BankName = "Test Bank",
                CardType = "Visa",
                Last4Digits = "3456",
                CreditLimit = 50000000,
                StatementDay = 15,
                DueDayOffset = 15,
                Status = CardStatus.Active,
                CreatedAt = DateTime.Now
            };
            var cardId = cardRepo.Add(card);

            var categoryRepo = new CategoryRepository();
            var categories = categoryRepo.GetAllCategories();

            var txService = new TransactionService();
            txService.AddTransaction(new Transaction
            {
                CardId = cardId,
                TransactionDate = DateTime.Today,
                MerchantName = "Test",
                Amount = 1000000,
                CategoryId = categories[0].Id
            });

            // Test
            var reportService = new ReportService();
            var from = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var to = DateTime.Today;
            var spending = reportService.GetSpendingByCategory(userId, from, to);
            
            Assert.IsTrue(spending.Count > 0);
        }
    }
}
