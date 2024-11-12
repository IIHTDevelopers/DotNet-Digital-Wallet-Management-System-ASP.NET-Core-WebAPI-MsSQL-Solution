
using DigitalWalletManagement.BusinessLayer.Interfaces;
using DigitalWalletManagement.BusinessLayer.Services.Repository;
using DigitalWalletManagement.BusinessLayer.Services;
using DigitalWalletManagement.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DigitalWalletManagement.Tests.TestCases
{
    public class BoundaryTests
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
        private readonly Payment _payment;
        private readonly Transaction _transaction;
        private readonly TwoFactorAuthenticationRequest _twoFactorAuthRequest;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_WalletId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repos => repos.MakeInstantPaymentAsync(1, 100, 1)).ReturnsAsync(_payment);
                var result = await _paymentService.MakeInstantPaymentAsync(1, 100, 1);
                if (result.WalletId!=0)
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
        public async Task<bool> Testfor_WalletBalance_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repos => repos.MakeInstantPaymentAsync(1, 100, 1)).ReturnsAsync(_payment);
                var result = await _paymentService.MakeInstantPaymentAsync(1, 100, 1);
                if (result.Amount != 0)
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
        public async Task<bool> Testfor_PaymentAmount_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repos => repos.MakeInstantPaymentAsync(1, 100, 1)).ReturnsAsync(_payment);
                var result = await _paymentService.MakeInstantPaymentAsync(1, 100, 1);
                if (result.Amount>0)
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
        public async Task<bool> Testfor_PaymentReceptientId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repos => repos.MakeInstantPaymentAsync(1, 100, 1)).ReturnsAsync(_payment);
                var result = await _paymentService.MakeInstantPaymentAsync(1, 100, 1);
                if (result.RecipientId!=0)
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
        public async Task<bool> Testfor_PaymentScheduleId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                paymentservice.Setup(repos => repos.MakeInstantPaymentAsync(1, 100, 1)).ReturnsAsync(_payment);
                var result = await _paymentService.MakeInstantPaymentAsync(1, 100, 1);
                if (result.ScheduleId != 0)
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