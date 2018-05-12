using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produto
{
    public class NomeIsNullOrEmpty : BusinessException
    {
        public NomeIsNullOrEmpty() : base("Nome do produto não pode ser vazio!")
        {
        }
    }
}
