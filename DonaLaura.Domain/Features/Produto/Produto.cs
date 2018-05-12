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
        public double PrecoVenda;
        public double PrecoCusto;
        public bool Diponibilidade;
        public DateTime DataFabricacao;
        public DateTime DataValidade;

        public void Validacao()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new NomeIsNullOrEmpty();

            if(Nome.Length < 4)
                throw new NomeIsToShort();

            if (Nome.Length > 25)
                throw new NomeIsToLong();

            if (PrecoCusto > PrecoVenda)
                throw new PrecoCustoMaiorPrecoVenda();

            if (DataValidade < DataFabricacao)
                throw new DataValidadeMenorDataFabricacao();
        }
    }
}
