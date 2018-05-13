using DonaLaura.Domain.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Common.Tests.Features.Produtos
{
    public static partial class ObjectMotherProduct
    {
        public static Produto GetProduto()
        {
            Produto produto = new Produto()
            {
                Id = 1,
                Nome = "Teclado",
                PrecoVenda = 150,
                PrecoCusto = 100,
                Diponibilidade = true,
                DataFabricacao = DateTime.Now.AddMonths(-10),
                DataValidade = DateTime.Now.AddDays(100),
            };
            return produto;
        }

        public static Produto GetProdutoSemNome()
        {
            Produto produto = new Produto()
            {
                Id = 1,
                Nome = "",
                PrecoVenda = 150,
                PrecoCusto = 100,
                Diponibilidade = true,
                DataFabricacao = DateTime.Now.AddMonths(-10),
                DataValidade = DateTime.Now.AddDays(100),
            };
            return produto;
        }

        public static IEnumerable<Produto> GetProdutos()
        {
            IEnumerable<Produto> produtos = new List<Produto>()
            {
                new Produto()
                {
                    Id = 1,
                    Nome = "Monitor",
                    PrecoVenda = 150,
                    PrecoCusto = 100,
                    Diponibilidade = true,
                    DataFabricacao = DateTime.Now.AddMonths(-10),
                    DataValidade = DateTime.Now.AddDays(100),
                },
                new Produto()
                {
                    Id = 2,
                    Nome = "MousePad",
                    PrecoVenda = 150,
                    PrecoCusto = 100,
                    Diponibilidade = true,
                    DataFabricacao = DateTime.Now.AddMonths(-10),
                    DataValidade = DateTime.Now.AddDays(100),
                },
                new Produto()
                {
                    Id = 3,
                    Nome = "HadSet",
                    PrecoVenda = 150,
                    PrecoCusto = 100,
                    Diponibilidade = true,
                    DataFabricacao = DateTime.Now.AddMonths(-10),
                    DataValidade = DateTime.Now.AddDays(100),
                }
            };
            return produtos;
        }
    }
}
