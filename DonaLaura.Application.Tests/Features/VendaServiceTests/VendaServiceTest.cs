using DonaLaura.Application.Features.Vendas;
using DonaLaura.Common.Tests.Features.Vendas;
using DonaLaura.Domain.Features.Vendas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Application.Tests.Features.VendaServiceTests
{

    [TestFixture]
    public class VendaServiceTest
    {
        IVendaService _vendaService;
        private Mock<IVendaRepository> _vendaRepository;
        Venda _venda;
        IEnumerable<Venda> _vendas;

        [SetUp]
        public void Initilaze()
        {
            _vendaRepository = new Mock<IVendaRepository>();
            _vendaService = new VendaService(_vendaRepository.Object);
        }

        [Test]
        public void VendaService_Add_ShouldBeOk()
        {
            _venda = ObjectMotherSale.GetVenda();
            _vendaRepository.Setup(x => x.Save(_venda)).Returns(_venda);
            Venda venda = _vendaService.Add(_venda);
            _vendaRepository.Verify(x => x.Save(_venda));
            venda.Should().NotBeNull();
            venda.Id.Should().Be(1);
        }

        [Test]
        public void VendaService_Add_ShouldFail()
        {
            _venda = ObjectMotherSale.GetVendasSemCliente();
            Action action = () => _vendaService.Add(_venda);
            action.Should().Throw<ClienteIsNullOrEmpty>();
            _vendaRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void VendaService_Update_ShouldBeOk()
        {
            _venda = ObjectMotherSale.GetVenda();
            _vendaRepository.Setup(x => x.Update(_venda));
            _vendaService.Update(_venda);
            _vendaRepository.Verify(x => x.Update(_venda));
            _venda.Should().NotBeNull();
            _venda.Id.Should().Be(1);
        }

        [Test]
        public void VendaService_Update_ShouldBeFail()
        {
            _venda = ObjectMotherSale.GetVendasSemCliente();
            Action action = () => _vendaService.Update(_venda);
            action.Should().Throw<ClienteIsNullOrEmpty>();
            _vendaRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void VendaService_Delete_ShouldBeOk()
        {
            _venda = ObjectMotherSale.GetVenda();
            _vendaRepository.Setup(x => x.Delete(_venda));
            _vendaService.Delete(_venda);
            _vendaRepository.Verify(x => x.Delete(_venda));
        }

        [Test]
        public void VendaService_Get_ShouldBeOk()
        {
            _venda = ObjectMotherSale.GetVenda();
            _vendaRepository.Setup(x => x.Get(1)).Returns(_venda);
            _venda = _vendaService.Get(1);
            _vendaRepository.Verify(x => x.Get(1));
            _venda.Should().NotBeNull();
        }

        [Test]
        public void VendaService_GetAll_ShouldBeOk()
        {
            _vendas = ObjectMotherSale.GetVendas();
            _vendaRepository.Setup(x => x.GetAll()).Returns(_vendas);
            _vendas = _vendaService.GetAll();
            _vendaRepository.Verify(x => x.GetAll());
            _vendas.Should().NotBeNull();
            _vendas.Should().HaveCount(1);
        }

    }
}
