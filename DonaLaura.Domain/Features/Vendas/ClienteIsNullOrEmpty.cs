using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Vendas
{
    public class ClienteIsNullOrEmpty : Exception
    {
        public ClienteIsNullOrEmpty() : base("Nome do cliente não pode ser vazio!")
        {
        }
    }
}
