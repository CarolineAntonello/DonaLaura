using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Vendas
{
    public class ProdutoInvalido : Exception
    {
        public ProdutoInvalido() : base("Este produto não esta conforme os requisitos para ser vendido!")
        {
        }
    }
}
