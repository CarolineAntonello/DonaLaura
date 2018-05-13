using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Vendas;

namespace DonaLaura.Application.Features.Vendas
{
    public class VendaService : IVendaService
    {
        private IVendaRepository _repository;

        public VendaService(IVendaRepository _repository)
        {
            this._repository = _repository;
        }

        public Venda Add(Venda venda)
        {
            venda.Validacao();
            return _repository.Save(venda);
        }

        public void Update(Venda venda)
        {
            if (venda.Id == 0)
            {
                throw new IdentifierUndefinedException();
            }
            venda.Validacao();
            _repository.Update(venda);
        }

        public void Delete(Venda venda)
        {
            _repository.Delete(venda);
        }

        public Venda Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Venda> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
