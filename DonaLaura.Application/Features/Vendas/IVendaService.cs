using DonaLaura.Domain.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Application.Features.Vendas
{
    public interface IVendaService
    {
        Venda Add(Venda venda);
        void Update(Venda venda);
        void Delete(Venda venda);
        Venda Get(long id);
        IEnumerable<Venda> GetAll();
    }
}
