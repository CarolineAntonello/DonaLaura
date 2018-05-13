using DonaLaura.Application.Features.Produtos;
using DonaLaura.Common.Tests.Features.Produtos;
using DonaLaura.Domain.Features.Produtos;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Application.Tests.Features.ProdutoServiceTests
{
    [TestFixture]
    public class ProdutoServiceTest
    {
        IProdutoService _produtoService;
        private Mock<IProdutoRepository> _produtoRepository;
        Produto _produto;
        IEnumerable<Produto> _produtos;

        [SetUp]
        public void Initilaze()
        {
            _produtoRepository = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_produtoRepository.Object);
        }

        [Test]
        public void ProdutoService_Add_ShouldBeOk()
        {
            _produto = ObjectMotherProduct.GetProduto();
            _produtoRepository.Setup(x => x.Save(_produto)).Returns(_produto);
            Produto prod = _produtoService.Add(_produto);
            _produtoRepository.Verify(x => x.Save(_produto));
            prod.Should().NotBeNull();
            prod.Id.Should().Be(1);
        }

        [Test]
        public void ProdutoService_Add_ShouldFail()
        {
            _produto = ObjectMotherProduct.GetProdutoSemNome();
            Action action = () => _produtoService.Add(_produto);
            action.Should().Throw<NomeIsNullOrEmpty>();
            _produtoRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProdutoService_Update_ShouldBeOk()
        {
            _produto = ObjectMotherProduct.GetProduto();
            _produtoRepository.Setup(x => x.Update(_produto));
            _produtoService.Update(_produto);
            _produtoRepository.Verify(x => x.Update(_produto));
            _produto.Should().NotBeNull();
            _produto.Id.Should().Be(1);
        }

        [Test]
        public void ProdutoService_Update_ShouldBeFail()
        {
            _produto = ObjectMotherProduct.GetProdutoSemNome();
            Action action = () => _produtoService.Update(_produto);
            action.Should().Throw<NomeIsNullOrEmpty>();
            _produtoRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProdutoService_Delete_ShouldBeOk()
        {
            _produto = ObjectMotherProduct.GetProduto();
            _produtoRepository.Setup(x => x.Delete(_produto));
            _produtoService.Delete(_produto);
            _produtoRepository.Verify(x => x.Delete(_produto));
        }

        [Test]
        public void ProdutoService_Get_ShouldBeOk()
        {
            _produto = ObjectMotherProduct.GetProduto();
            _produtoRepository.Setup(x => x.Get(1)).Returns(_produto);
            _produto = _produtoService.Get(1);
            _produtoRepository.Verify(x => x.Get(1));
            _produto.Should().NotBeNull();
        }

        [Test]
        public void ProdutoService_GetAll_ShouldBeOk()
        {
            _produtos = ObjectMotherProduct.GetProdutos();
            _produtoRepository.Setup(x => x.GetAll()).Returns(_produtos);
            _produtos = _produtoService.GetAll();
            _produtoRepository.Verify(x => x.GetAll());
            _produtos.Should().NotBeNull();
            _produtos.Should().HaveCount(3);
        }

    }
}
