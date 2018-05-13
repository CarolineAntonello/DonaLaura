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
            ProdutoSqlTest.SeedDatabase();
            _repository = new ProdutoSqlRepository();
        }

        [Test]
        public void ProdutoSql_Save_ShouldBeOk()
        {
            _produto = ObjectMotherProduct.GetProduto();
            _produto = _repository.Save(_produto);
            _produto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void PostSql_Save_ShouldBefail()
        {
            _produto = ObjectMotherProduct.GetProdutoSemNome();
            Action action = () => _repository.Save(_produto);
            action.Should().Throw<NomeIsNullOrEmpty>();
        }

        [Test]
        public void PostSql_Update_ShouldBeOk()
        {
            _produto = ObjectMotherProduct.GetProduto();
            _repository.Update(_produto);
            Produto p = _repository.Get(_produto.Id);
            _produto.Nome.Should().Be(p.Nome);
        }

        [Test]
        public void PostSql_Update_ShouldBeFail()
        {
            _produto = ObjectMotherProduct.GetProdutoSemNome();
            Action action = () => _repository.Update(_produto);
            action.Should().Throw<NomeIsNullOrEmpty>();
        }

        [Test]
        public void PostSql_Delete_ShouldBeOk()
        {
            _produto = ObjectMotherProduct.GetProduto();
            _repository.Delete(_produto);
            Produto p = _repository.Get(_produto.Id);
            p.Should().BeNull();
        }

        [Test]
        public void PostSql_GetAll_ShouldBeOk()
        {
            IEnumerable<Produto> posts = ObjectMotherProduct.GetProdutos();
            foreach (var post in posts)
            {
                _repository.Save(post);
            }
            IEnumerable<Produto> p = _repository.GetAll();
            p.Count().Should().Be(3);
        }
    }
}
