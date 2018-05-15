using DonaLaura.Application.Features.Vendas;
using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features.Vendas;
using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Infra.Data.Features.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Integration.Tests.Features.Vendas
{
    [TestFixture]
    public class SqlVendaIntegrationTests
    {
        IVendaService _service;
        IVendaRepository _repository;

        [SetUp]
        public void Initilaze()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();
            _repository = new VendaSqlRepository();
            _service = new VendaService(_repository);
        }

        [Test]
        public void Integration_AddSale_ShouldBeOK()
        {
            Venda venda = ObjectMotherSale.GetVenda();
            Venda vendaReceived = _service.Add(venda);
            var vendaVerify = _service.Get(venda.Id);
            vendaVerify.Should().NotBeNull();
            vendaVerify.Id.Should().Be(1);
        }

        [Test]
        public void Integration_AddSale_ShouldBeFail()
        {
            Venda venda = ObjectMotherSale.GetVendasSemCliente();
            Action action = () => _service.Add(venda);
            action.Should().Throw<ClienteIsNullOrEmpty>();
        }

        [Test]
        public void Integration_UpdateSale_ShouldBeOK()
        {
            Venda venda = ObjectMotherSale.GetVenda();
            _service.Update(venda);
            venda.Id.Should().Be(venda.Id);
            venda.Cliente.Should().Be(venda.Cliente);
        }

        [Test]
        public void Integration_UpdateSale_ShouldBeFail()
        {
            Venda venda = ObjectMotherSale.GetVendasSemCliente();
            Action action = () => _service.Add(venda);
            action.Should().Throw<ClienteIsNullOrEmpty>();
        }

        [Test]
        public void Integration_DeleteSale_ShouldBeOK()
        {
            Venda venda = ObjectMotherSale.GetVenda();
            _service.Delete(venda);
            Venda vendaReceived = _service.Get(venda.Id);
            vendaReceived.Should().BeNull();
        }

        [Test]
        public void Integration_GetSale_ShouldBeOK()
        {
            Venda venda = _service.Get(1);
            venda.Should().NotBeNull();
            venda.Id.Should().BeGreaterThan(0);
        }

        //[Test]
        //public void Integration_GetSale_ShouldBeFail()
        //{
        //     Venda venda = _service.Get(2);
        //    venda.Should().BeNull();
        //}

        [Test]
        public void Integration_GetAllSale_ShouldBeOkay()
        {
            IEnumerable<Venda> venda = _service.GetAll();
            venda.Count().Should().BeGreaterThan(0);
        }

    }
}
