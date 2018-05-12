using DonaLaura.Domain.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Application.Features.Produtos
{
    public interface IProdutoService
    {
        Produto Add(Produto post);
        void Update(Produto post);
        Produto Get(long id);
        IEnumerable<Produto> GetAll();
        void Delete(Produto post);
    }
}
