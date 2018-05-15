using DonaLaura.Application.Features.Produtos;
using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features.Produtos;
using DonaLaura.Domain.Features.Produtos;
using DonaLaura.Infra.Data.Features.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Integration.Tests.Features.Produtos
{
    [TestFixture]
    public class SqlProdutoIntegrationTests
    {
        IProdutoService _service;
        IProdutoRepository _repository;

        [SetUp]
        public void Initilaze()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();
            _repository = new ProdutoSqlRepository();
            _service = new ProdutoService(_repository);
        }

        [Test]
        public void Integration_AddProduct_ShouldBeOK()
        {
            Produto produto = ObjectMotherProduct.GetProduto();
            Produto produtoReceived = _service.Add(produto);
            var produtoVerify = _service.Get(produto.Id);
            produtoVerify.Should().NotBeNull();
            produtoVerify.Id.Should().Be(produto.Id);
        }

        [Test]
        public void Integration_AddProduct_ShouldBeFail()
        {
            Produto produto = ObjectMotherProduct.GetProdutoSemNome();
            Action action = () => _service.Add(produto);
            action.Should().Throw<NomeIsNullOrEmpty>();
        }

        [Test]
        public void Integration_UpdateProduct_ShouldBeOK()
        {
            Produto produto = ObjectMotherProduct.GetProduto();
            _service.Update(produto);
            produto.Id.Should().Be(produto.Id);
            produto.Nome.Should().Be(produto.Nome);
        }

        [Test]
        public void Integration_UpdateProduct_ShouldBeFail()
        {
            Produto produto = ObjectMotherProduct.GetProdutoSemNome();
            Action action = () => _service.Add(produto);
            action.Should().Throw<NomeIsNullOrEmpty>();
        }

        [Test]
        public void Integration_DeleteProduct_ShouldBeOK()
        {
            Produto produto = ObjectMotherProduct.GetProduto();
            _service.Delete(produto);
            Produto produtoReceived = _service.Get(produto.Id);
            produtoReceived.Should().BeNull();
        }

        [Test]
        public void Integration_GetProduct_ShouldBeOK()
        {
            Produto produto = _service.Get(1);
            produto.Should().NotBeNull();
            produto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Integration_GetProduct_ShouldBeFail()
        {
            Produto produto = _service.Get(200);
            produto.Should().BeNull();
        }

        [Test]
        public void Integration_GetAllProducts_ShouldBeOkay()
        {
            IEnumerable<Produto> produto = _service.GetAll();
            produto.Count().Should().BeGreaterThan(0);
        }

    }
}
