using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produto
{
    public class Produto
    {
        public long Id;
        public string Nome;
        public double Precovenda;
        public double PrecoCusto;
        public bool Diponibilidade;
        public DateTime DataFabricacao;
        public DateTime DataValidade;

        public void Validacao()
        {

        }
    }
}
