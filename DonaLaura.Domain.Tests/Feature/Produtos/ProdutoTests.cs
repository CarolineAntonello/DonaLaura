using DonaLaura.Domain.Features.Produto;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Tests.Feature.Produtos
{
    [TestFixture]
    public class ProdutoTests
    {
        private Produto _produto;

        [SetUp]
        public void Initilaze()
        {
            _produto = new Produto();
        }

        [Test]
        public void Domain_Produto_Nome_Vazio()
        {
            Assert.Throws<NomeIsNullOrEmpty>(() => _produto.Validacao());
        }

        [Test]
        public void Domain_Produto_Nome_Muito_Curto()
        {
            _produto.Nome = "eu";
            Assert.Throws<NomeIsToShort>(() => _produto.Validacao());
        }

        [Test]
        public void Domain_Produto_Nome_Muito_Longo()
        {
            _produto.Nome = "eueueueueueueueueueueueueueueueueueueu";
            Assert.Throws<NomeIsToLong>(() => _produto.Validacao());
        }

        [Test]
        public void Domain_Produto_PrecoCusto_Menor_PrecoVenda()
        {
            _produto.Nome = "Teste";
            _produto.PrecoCusto = 100;
            _produto.PrecoVenda = 50;
            Assert.Throws<PrecoCustoMaiorPrecoVenda>(() => _produto.Validacao());
        }


        [Test]
        public void Domain_Produto_DataValidade_Menor_DataFabricacao()
        {
            _produto.Nome = "Teste";
            _produto.PrecoCusto = 50;
            _produto.PrecoVenda = 100;
            _produto.DataValidade = DateTime.Now;
            _produto.DataFabricacao = DateTime.Now.AddDays(5);
            Assert.Throws<DataValidadeMenorDataFabricacao>(() => _produto.Validacao());
        }

        [Test]
        public void Domain_Produto_Verificando_Todos_Campos()
        {
            _produto.Nome = "Mouse";
            _produto.PrecoCusto = 30;
            _produto.PrecoVenda = 55;
            _produto.Diponibilidade = true;
            _produto.DataFabricacao = DateTime.Now.AddDays(-5);
            _produto.DataValidade = DateTime.Now.AddMonths(10);
            Assert.DoesNotThrow(_produto.Validacao);
        }

    }
}
