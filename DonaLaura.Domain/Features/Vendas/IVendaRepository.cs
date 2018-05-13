using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Vendas
{
    public interface IVendaRepository
    {
        Venda Save(Venda venda);
        void Update(Venda postvenda);
        void Delete(Venda venda);
        Venda Get(long id);
        IEnumerable<Venda> GetAll();
    }
}
