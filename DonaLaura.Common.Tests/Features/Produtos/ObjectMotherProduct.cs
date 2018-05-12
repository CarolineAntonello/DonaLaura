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
                Nome = "Teclado",
                PrecoVenda = 150,
                PrecoCusto = 100,
                Diponibilidade = true,
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddDays(1000),
            };
            return produto;
        }
    }
}
