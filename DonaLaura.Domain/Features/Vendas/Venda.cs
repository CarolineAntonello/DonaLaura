using DonaLaura.Domain.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DonaLaura.Domain.Features.Vendas
{
    public class Venda
    {
        public Produto produto = new Produto();
        public long Id;
        public long ProdutoId;
        public string Cliente;
        public int Quantidade;
        public double Lucro;

        public void Validacao()
        {

            if (string.IsNullOrEmpty(Cliente))
                throw new ClienteIsNullOrEmpty();

            if (Quantidade <= 0)
                throw new QuantidadeMenorQueZero();

            if (ProdutoId <= 0 && produto.Disponibilidade == false && produto.DataValidade < DateTime.Now)
                throw new ProdutoInvalido();

        }

        public void CalculaLucro()
        {
            Lucro = produto.PrecoVenda - produto.PrecoCusto;
        }

    }
}
