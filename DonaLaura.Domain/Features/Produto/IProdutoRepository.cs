using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produto
{
    public interface IProdutoRepository
    {
        Produto Save(Produto produto);
        void Update(Produto postproduto);
        Produto Get(long id);
        IEnumerable<Produto> GetAll();
        void Delete(Produto produto);
    }
}
