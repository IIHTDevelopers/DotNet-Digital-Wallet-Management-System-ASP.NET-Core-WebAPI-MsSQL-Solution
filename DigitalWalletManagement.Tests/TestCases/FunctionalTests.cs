
using DigitalWalletManagement.BusinessLayer.Interfaces;
using DigitalWalletManagement.BusinessLayer.Services;
using DigitalWalletManagement.BusinessLayer.Services.Repository;
using DigitalWalletManagement.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DigitalWalletManagement.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IWalletService _walletService;
        private readonly IPaymentService _paymentService;
        private readonly ITransactionService _transactionService;
        private readonly ISecurityService _securityService;

        public readonly Mock<IWalletRepository> walletservice = new Mock<IWalletRepository>();
        public readonly Mock<IPaymentRepository> paymentservice = new Mock<IPaymentRepository>();
        public readonly Mock<ITransactionRepository> transactionservice = new Mock<ITransactionRepository>();
        public readonly Mock<ISecurityRepository> securityservice = new Mock<ISecurityRepository>();

        private readonly Wallet _wallet;
        private readonly List<Wallet> _walletList;
        private readonly Payment _payment;
        private readonly Transaction _transaction;
        private readonly List<Transaction> _transactionList;
        private readonly TwoFactorAuthenticationRequest _twoFactorAuthRequest;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _walletService = new WalletService(walletservice.Object);
            _paymentService = new PaymentService(paymentservice.Object);
            _transactionService = new TransactionService(transactionservice.Object);
            _securityService = new SecurityService(securityservice.Object);

            _output = output;

            _wallet = new Wallet
            {
                UserId = 1,
                WalletId = 1,
                Balance = 100,
                CreatedAt = DateTime.Now,
                Name = "user"
            };

            _payment = new Payment
            {
                Amount = 100,
                Frequency = "N",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                RecipientId = 1,
                ScheduleId = 1,
                WalletId = 1
            };
            _walletList = new List<Wallet>
             {
               new Wallet
            {
                UserId = 1,
                WalletId = 1,
                Balance = 100,
                CreatedAt = DateTime.Now,
                Name = "user"
            } };
            _transactionList = new List<Transaction>
             {
               new Transaction
            {
                Amount = 100,
                Date = DateTime.Now,
                Status = "New",
                TransactionId = 1,
                Type = "NA",
                WalletId = 1
            } };
            _transaction = new Transaction
            {
                Amount = 100,
                Date = DateTime.Now,
                Status = "New",
                TransactionId = 1,
                Type = "NA",
                WalletId = 1
            };

            _twoFactorAuthRequest = new TwoFactorAuthenticationRequest
            {
                AuthId = 1,
                CreatedDate = DateTime.Now,
                IsEnabled = true,
                PhoneNumber = "123456789",
                UserId = 1
            };
        }


        [Fact]
        public async Task<bool> Testfor_Create_Wallet()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                walletservice.Setup(repos => repos.AddAsync(_wallet)).ReturnsAsync(_wallet);
                var result = await _walletService.AddAsync(_wallet);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_Update_Wallet()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                walletservice.Setup(repos => repos.UpdateAsync(_wallet)).ReturnsAsync(_wallet);
                var result = await _walletService.UpdateAsync(_wallet);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_GetWalletById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                walletservice.Setup(repos => repos.GetByIdAsync(id)).ReturnsAsync(_wallet);
                var result = await _walletService.GetByIdAsync(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_DeleteWalletById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                walletservice.Setup(repos => repos.DeleteAsync(id)).ReturnsAsync(response);
                var result = await _walletService.DeleteAsync(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_GetAllWalletDetails()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                walletservice.Setup(repos => repos.GetAll()).ReturnsAsync(_walletList);
                var result = await _walletService.GetAll();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_Instant_Payment()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repos => repos.MakeInstantPaymentAsync(1, 100, 1)).ReturnsAsync(_payment);
                var result = await _paymentService.MakeInstantPaymentAsync(1, 100, 1);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Add_Transaction()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                transactionservice.Setup(repos => repos.AddTransactionAsync(_transaction)).ReturnsAsync(_transaction);
                var result = await _transactionService.AddTransactionAsync(_transaction);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_GetTransaction_Details()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                transactionservice.Setup(repos => repos.GetTransactionDetailAsync(1)).ReturnsAsync(_transaction);
                var result = await _transactionService.GetTransactionDetailAsync(1);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_GetSecurity_AuditLogs()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                securityservice.Setup(repos => repos.GetSecurityAuditLogAsync(1)).ReturnsAsync(_twoFactorAuthRequest);
                var result = await _securityService.GetSecurityAuditLogAsync(1);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Setup_TwoFactorAuth()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                securityservice.Setup(repos => repos.SetupTwoFactorAuthenticationAsync(1,"123456789")).ReturnsAsync(_twoFactorAuthRequest);
                var result = await _securityService.SetupTwoFactorAuthenticationAsync(1,"123456789");
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}