using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features.Vendas;
using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Infra.Data.Features.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Tests.Feature.Vendas
{
    [TestFixture]
    class VendaSqlRepositoryTests
    {
        private IVendaRepository _repository;
        private Venda _venda;

        [SetUp]
        public void Initilaze()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();
            _repository = new VendaSqlRepository();
        }

        [Test]
        public void SaleSql_Save_ShouldBeOk()
        {
            _venda = ObjectMotherSale.GetVendaSemId();
            _venda = _repository.Save(_venda);
            _venda.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void SaleSql_Save_ShouldBefail()
        {
            _venda = ObjectMotherSale.GetVendasSemCliente();
            Action action = () => _repository.Save(_venda);
            action.Should().Throw<ClienteIsNullOrEmpty>();
        }

        [Test]
        public void SaleSql_Update_ShouldBeOk()
        {
            _venda = ObjectMotherSale.GetVenda();
            _repository.Update(_venda);
            Venda p = _repository.Get(_venda.Id);
            _venda.Cliente.Should().Be(p.Cliente);
        }

        [Test]
        public void SaleSql_Update_ShouldBeFail()
        {
            _venda = ObjectMotherSale.GetVendasSemCliente();
            Action action = () => _repository.Update(_venda);
            action.Should().Throw<ClienteIsNullOrEmpty>();
        }

        [Test]
        public void SaleSql_Delete_ShouldBeOk()
        {
            _venda = ObjectMotherSale.GetVenda();
            _repository.Delete(_venda);
            Venda p = _repository.Get(_venda.Id);
            p.Should().BeNull();
        }

        [Test]
        public void SaleSql_GetAll_ShouldBeOk()
        {
            IEnumerable<Venda> posts = ObjectMotherSale.GetVendas();
            foreach (var post in posts)
            {
                _repository.Save(post);
            }
            IEnumerable<Venda> p = _repository.GetAll();
            p.Count().Should().Be(3);
        }
    }
}
