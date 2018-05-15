using DonaLaura.Domain.Features.Produtos;
using DonaLaura.Domain.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Common.Tests.Features.Vendas
{
    public class ObjectMotherSale
    {
        public static Venda GetVendaSemId()
        {
            Venda venda = new Venda()
            {
                ProdutoId = 1,
                Cliente = "Vinícius",
                Quantidade = 1,
                Lucro = 15,
            };
            return venda;
        }

        public static Venda GetVenda()
        {
            Venda venda = new Venda()
            {
                Id = 1,
                ProdutoId = 1,
                Cliente = "Vinícius",
                Quantidade = 1,
                Lucro = 15,
            };
            return venda;
        }

        public static Venda GetVendasSemCliente()
        {
            Venda venda = new Venda()
            {
                Id = 1,
                ProdutoId = 1,
                Cliente = "",
                Quantidade = 1,
                Lucro = 15,
            };
            return venda;
        }

        public static IEnumerable<Venda> GetVendas()
        {
            IEnumerable<Venda> venda = new List<Venda>()
            {
                new Venda()
                {
                    Id =1,
                    ProdutoId = 1,
                    Cliente = "Vinícius",
                    Quantidade = 1,
                    Lucro = 15,
                },
                //new Venda()
                //{
                //    Id = 2,
                //    ProdutoId = 2,
                //    Cliente = "Xivits",
                //    Quantidade = 1,
                //    Lucro = 15,
                //},
                //new Venda()
                //{
                //    Id = 3,
                //    ProdutoId = 2,
                //    Cliente = "Carol",
                //    Quantidade = 1,
                //    Lucro = 15,
                //}
            };
            return venda;
        }
    }
}
