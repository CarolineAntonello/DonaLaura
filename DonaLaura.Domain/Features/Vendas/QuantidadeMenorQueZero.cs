using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Vendas
{
    public class QuantidadeMenorQueZero : Exception
    {
        public QuantidadeMenorQueZero() : base("A quantidade não pode ser menor que zero!")
        {
        }
    }
}
