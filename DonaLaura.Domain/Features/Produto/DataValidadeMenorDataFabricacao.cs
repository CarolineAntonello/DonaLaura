using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produto
{
    public class DataValidadeMenorDataFabricacao : Exception
    {
        public DataValidadeMenorDataFabricacao() : base("Data de validade menor que data de fabricação!")
        {
        }
    }
}
