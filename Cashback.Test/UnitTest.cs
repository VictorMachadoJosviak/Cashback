using Cashback.API.Controllers;
using Cashback.Infra.DTO.Sale;
using Cashback.Infra.Enums;
using Cashback.Infra.Helpers;
using Cashback.Infra.Presistence;
using Cashback.Infra.Transactions;
using Cashback.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Cashback.Test
{
    public class Tests
    {
        private Mock<ISaleService> _mock;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<ISaleService>();            
        }

        [Test]
        public void TestCreateSale()
        {

            var returns = new SaleDTO
            {
                Code = "12300",
                Date = DateTime.Now,
                ResellerId = new Guid("027bc4bb-9b66-4b18-9f9d-8705f87ebc95"),
                SaleStatus = SaleStatus.InValidation,
                Value = 23,
                Status = "Em Validação"
            };

            var create = new CreateSaleDTO
            {
                Code = "12300",
                CPF = "05524947982",
                Date = DateTime.Now,
                Value = 23
            };

            _mock.Setup(x => x.CreateSale(create)).Returns(Task.FromResult(returns));

            Assert.AreEqual(create.Code,returns.Code);
        }

        [Test]
        public void TestDeleteSale()
        {
            _mock.Setup(x =>  x.CodeNotExists("123213")).Returns(Task.FromResult(true));       
        }
    }
}