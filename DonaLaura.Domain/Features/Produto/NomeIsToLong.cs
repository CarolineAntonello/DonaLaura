using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produto
{
    public class NomeIsToLong : Exception
    {
        public NomeIsToLong() : base("Nome ultrapassou o limite de caracteres!")
        {
        }
    }
}
