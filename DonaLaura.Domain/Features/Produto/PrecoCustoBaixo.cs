using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produto
{
    public class PrecoCustoMaiorPrecoVenda : Exception
    {
        public PrecoCustoMaiorPrecoVenda() : base("Preço de custo maior que preço de venda")
        {
        }
    }
}
