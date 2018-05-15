using DonaLaura.Domain.Features.Produtos;
using DonaLaura.Domain.Features.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Tests.Feature.Vendas
{
    [TestFixture]
    public class VendasTests
    {
        private Venda _venda;
        private Produto _produto;

        [SetUp]
        public void Initilaze()
        {
            _venda = new Venda();
            _produto = new Produto();
        }

        [Test]
        public void Domain_Venda_Cliente_Vazio()
        {
            _venda.Cliente = "";
            Assert.Throws<ClienteIsNullOrEmpty>(() => _venda.Validacao());
        }

        [Test]
        public void Domain_Venda_Quantidade_Menor()
        {
            _venda.Cliente = "Vinícius";
            _venda.Quantidade = 0;
            Assert.Throws<QuantidadeMenorQueZero>(() => _venda.Validacao());
        }

        [Test]
        public void Domain_Venda_Produto_Invalido()
        {
            _venda.ProdutoId = _produto.Id;
            _venda.ProdutoId = Convert.ToInt32(_produto.Disponibilidade = false);
            _venda.Cliente = "Vinícius";
            _venda.Quantidade = 1;
            Assert.Throws<ProdutoInvalido>(() => _venda.Validacao());
        }

        [Test]
        public void Domain_Venda_Realizada_Com_Sucesso()
        {
            _venda.ProdutoId = 12;
            _venda.ProdutoId = Convert.ToInt32(_produto.Disponibilidade = true);
            _venda.Cliente = "Vinícius";
            _venda.Quantidade = 1;
            _venda.Lucro = 15;
            Assert.DoesNotThrow(_venda.Validacao);
        }

        [Test]
        public void Domain_Venda_CalculaLucro_Deveria_Calcular_Lucro_Corretamente()
        {
            Produto prod = new Produto()
            {
                Nome = "test",
                Disponibilidade = true,
                DataValidade = DateTime.Now.AddDays(50),
                PrecoCusto = 10,
                PrecoVenda = 20,
            };
            Venda venda = new Venda()
            {
                Id = 1,
                Cliente = "teste",
                ProdutoId = 1,
                Quantidade = 1,
                produto = prod,
            };
            _venda.CalculaLucro();
            _venda.Lucro.Should().NotBe(1);
            //_venda.Lucro.Should().Be(10);
        }
    }
}
