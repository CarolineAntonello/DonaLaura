using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Produtos;

namespace DonaLaura.Application.Features.Produtos
{
    public class ProdutoService : IProdutoService
    {
        IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public Produto Add(Produto produto)
        {
            produto.Validacao();
            return _repository.Save(produto);
        }

        public void Update(Produto produto)
        {
            if (produto.Id == 0)
            {
                throw new IdentifierUndefinedException();
            }
            produto.Validacao();
            _repository.Update(produto);
        }

        public void Delete(Produto produto)
        {
            _repository.Delete(produto);
        }

        public Produto Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
