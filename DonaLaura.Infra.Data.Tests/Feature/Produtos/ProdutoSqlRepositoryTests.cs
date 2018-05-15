using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features.Produtos;
using DonaLaura.Domain.Features.Produtos;
using DonaLaura.Infra.Data.Features.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Infra.Data.Tests.Feature.Produtos
{
    [TestFixture]
    class ProdutoSqlRepositoryTests
    {
        private IProdutoRepository _repository;
        private Produto _produto;

        [SetUp]
        public void Initilaze()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();
            _repository = new ProdutoSqlRepository();
        }

        [Test]
        public void ProductSql_Save_ShouldBeOk()
        {
            _produto = ObjectMotherProduct.GetProdutoSemId();
            _produto = _repository.Save(_produto);
            _produto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProductSql_Save_ShouldBefail()
        {
            _produto = ObjectMotherProduct.GetProdutoSemNome();
            Action action = () => _repository.Save(_produto);
            action.Should().Throw<NomeIsNullOrEmpty>();
        }

        [Test]
        public void ProductSql_Update_ShouldBeOk()
        {
            _produto = ObjectMotherProduct.GetProduto();
            _repository.Update(_produto);
            Produto p = _repository.Get(_produto.Id);
            _produto.Nome.Should().Be("Teclado");
        }

        [Test]
        public void ProductSql_Update_ShouldBeFail()
        {
            _produto = ObjectMotherProduct.GetProdutoSemNome();
            Action action = () => _repository.Update(_produto);
            action.Should().Throw<NomeIsNullOrEmpty>();
        }

        [Test]//conflito
        public void ProductSql_Delete_ShouldBeOk()
        {
            _produto = ObjectMotherProduct.GetProduto();
            _repository.Delete(_produto);
            Produto p = _repository.Get(_produto.Id);
            p.Should().BeNull();
        }

        [Test]
        public void ProductSql_GetAll_ShouldBeOk()
        {
            IEnumerable<Produto> posts = ObjectMotherProduct.GetProdutos();
            foreach (var post in posts)
            {
                _repository.Save(post);
            }
            IEnumerable<Produto> p = _repository.GetAll();
            p.Count().Should().Be(4);
        }
    }
}
