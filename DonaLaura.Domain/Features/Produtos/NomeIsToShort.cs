using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produtos
{
    public class NomeIsToShort : Exception
    {
        public NomeIsToShort() : base("Nome não pode ter menos de 4 caracteres!")
        {
        }
    }
}
